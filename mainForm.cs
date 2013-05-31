using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Shell;
using Shell32;
using System.Drawing;
using System.Xml;

namespace JumpListMakerSharp
{
    public partial class mainForm : Form
    {
        private JumpList myjl;
        private ListViewHitTestInfo hitinfo;
        private TextBox editbox = new TextBox();
        private List<Task> tasks;
        private DialogResult dr;
        private int imgCount = 0;
        private List<string> fileNotFoundPaths = new List<string>();
        private string workDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JumpListMakerSharp");

        public mainForm()
        {
            InitializeComponent();
            startup();
        }

        public mainForm(string file)
        {
            InitializeComponent();
            startup();
            clickFile(file);
        }

        private void addTask()
        {
            if ((txtName.Text.Length != 0) && (txtPath.Text.Length != 0))
            {
                ListViewItem it = new ListViewItem();
                it.SubItems.Add(txtName.Text);
                it.SubItems.Add(txtTooltip.Text);
                it.SubItems.Add(txtPath.Text);
                it.SubItems.Add(txtArgs.Text);
                it.Checked = true;
                GroupItem(it);
                FileAttributes fa = System.IO.File.GetAttributes(txtPath.Text);
                if (fa == FileAttributes.Directory)
                {
                    imageList1.Images.Add(Get.icon(txtPath.Text, Get.FileIconSize.Small, true));
                }
                else
                {
                    imageList1.Images.Add(Get.icon(txtPath.Text, Get.FileIconSize.Small, false));
                }
                it.ImageIndex = imgCount;
                imgCount++;
                lvList.Items.Add(it);
                lvList.SmallImageList = imageList1;
                resetText();
                this.Text = "JumpListMakerSharp - " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), JumpListMakerSharp.Properties.Settings.Default.saveFile);
                JumpListMakerSharp.Properties.Settings.Default.needSave = true;
            }
            else if (txtName.Text.Length != 0)
            {
                System.Windows.Forms.MessageBox.Show("Path field is required!", "JumpListMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetText();
            }
            else if (txtPath.Text.Length != 0)
            {
                System.Windows.Forms.MessageBox.Show("Name field is required!", "JumpListMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetText();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Name and Path fields are required!", "JumpListMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resetText();
            }
            checkGroups();
        }

        private void resetText()
        {
            txtCat.Text = "";
            txtName.Text = "";
            txtTooltip.Text = "";
            txtPath.Text = "";
            txtArgs.Text = "";
        }

        private void checkGroups()
        {
            List<ListViewGroup> remove = new List<ListViewGroup>();
            cmbGroups.Items.Clear();
            foreach (ListViewGroup group in lvList.Groups)
            {
                if (group.Items.Count > 0)
                {
                    cmbGroups.Items.Add(group.Header);
                }
                else
                {
                    remove.Add(group);
                }
            }
            foreach (ListViewGroup g in remove)
            {
                lvList.Groups.Remove(g);
            }
        }

        private void GroupItem(ListViewItem item)
        {
            // This flag will tell us if proper group already exists
            bool group_exists = false;
            // Check each group if it fits to the item
            foreach (ListViewGroup group in lvList.Groups)
            {
                // Compare group's header to selected subitem's text
                if (group.Header == txtCat.Text)
                {
                    // Add item to the group.
                    // Alternative is: group.Items.Add(item);
                    item.Group = group;
                    group_exists = true;
                    break;
                }
            }
            // Create new group if no proper group was found
            if (!group_exists)
            {
                // Create group and specify its header by
                // getting selected subitem's text
                ListViewGroup group = new ListViewGroup(txtCat.Text);
                // We need to add the group to the ListView first
                lvList.Groups.Add(group);
                item.Group = group;
            }
        }

        private void setTooltip()
        {
            new CustomToolTip(groupBox2, "Choose existing categories or add a new one.");
            new CustomToolTip(txtCat, "Choose existing categories or add a new one.");
            new CustomToolTip(cmbGroups, "Choose existing categories or add a new one.");
            new CustomToolTip(lvList, "Double Right Click to edit.\nLeft Double Click to toogle activation.");
            new CustomToolTip(txtName, "The string that will represent the item in the jumplist.");
            new CustomToolTip(groupBox3, "The string that will represent the item in the jumplist.");
            new CustomToolTip(txtTooltip, "The tooltip that will appear hovering the mouse over the item in the jumplist.");
            new CustomToolTip(groupBox4, "The tooltip that will appear hovering the mouse over the item in the jumplist.");
            new CustomToolTip(cmdSwitch, "Switch the category of the selected item with the one in the textbox.");
        }

        private void startup()
        {
            editbox.Parent = lvList;
            editbox.Hide();
            editbox.KeyDown += new KeyEventHandler(editbox_KeyDown);
            lvList.MouseDoubleClick += new MouseEventHandler(lvList_DoubleClick);
            this.FormClosing += new FormClosingEventHandler(mainForm_FormClosing);
            lvList.FullRowSelect = true;
            setTooltip();
            if (JumpListMakerSharp.Properties.Settings.Default.saveFile.Length == 0)
            {
                JumpListMakerSharp.Properties.Settings.Default.saveFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "unsaved jumplist.jlxml");
            }
            JumpListMakerSharp.Properties.Settings.Default.needSave = false;
            tsmSave.Enabled = false;
            tsmSaveFile.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = JumpListMakerSharp.Properties.Resources.icon;
        }

        #region save-load-file

        private void clickFile(string path)
        {
            imgCount = 0;
            DataSet ds = new DataSet();
            lvList.Items.Clear();
            lvList.Groups.Clear();
            ds.ReadXml(path);
            DataTable dt = ds.Tables[0];
            List<string> groups = new List<string>();
            List<string> groupsclean = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                groups.Add(dr[0].ToString());
            }

            foreach (string s in groups)
            {
                if (!groupsclean.Contains(s))
                {
                    groupsclean.Add(s);
                }
            }

            foreach (string s in groupsclean)
            {
                lvList.Groups.Add(new ListViewGroup(s));
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = null;
                FileAttributes fa;
                try
                {
                    dr = dt.Rows[i];
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        ListViewItem lvi = new ListViewItem();
                        if (dr[1].ToString().Equals("True"))
                        {
                            lvi.Checked = true;
                        }
                        else
                        {
                            lvi.Checked = false;
                        }
                        lvi.SubItems.Add(dr[2].ToString());
                        lvi.SubItems.Add(dr[3].ToString());
                        lvi.SubItems.Add(dr[4].ToString());
                        lvi.SubItems.Add(dr[5].ToString());

                        fa = System.IO.File.GetAttributes(dr[4].ToString());
                        if (fa == FileAttributes.Directory)
                        {
                            imageList1.Images.Add(Get.icon(dr[4].ToString(), Get.FileIconSize.Small, true));
                        }
                        else
                        {
                            imageList1.Images.Add(Get.icon(dr[4].ToString(), Get.FileIconSize.Small, false));
                        }
                        lvi.ImageIndex = imgCount;
                        imgCount++;
                        lvList.SmallImageList = imageList1;

                        foreach (ListViewGroup group in lvList.Groups)
                        {
                            if (group.Header.Equals(dr[0].ToString()))
                            {
                                lvi.Group = group;
                            }
                        }
                        lvList.Items.Add(lvi);
                    }
                }
                catch (Exception ex) { fileNotFoundPaths.Add(dr[4].ToString()); }
            }
            checkGroups();
            JumpListMakerSharp.Properties.Settings.Default.saveFile = path;
            this.Text = "JumpListMakerSharp - " + JumpListMakerSharp.Properties.Settings.Default.saveFile;
            JumpListMakerSharp.Properties.Settings.Default.needSave = false;
            purgeOld(path);
        }

        private void loadFile()
        {
            if (JumpListMakerSharp.Properties.Settings.Default.needSave == true)
            {
                if (DialogResult.Yes != MessageBox.Show(
                "Current JumpList has not been saved!",
                "Lose current jumplist?",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button2))
                {
                    return;
                }
            }
            DataSet ds = new DataSet();
            DialogResult result = ofdLoad.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (ofdLoad.FileName != "")
                {
                    imgCount = 0;
                    lvList.Items.Clear();
                    lvList.Groups.Clear();
                    ds.ReadXml(ofdLoad.FileName);
                    DataTable dt = ds.Tables[0];
                    List<string> groups = new List<string>();
                    List<string> groupsclean = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        groups.Add(dr[0].ToString());
                    }

                    foreach (string s in groups)
                    {
                        if (!groupsclean.Contains(s))
                        {
                            groupsclean.Add(s);
                        }
                    }

                    foreach (string s in groupsclean)
                    {
                        lvList.Groups.Add(new ListViewGroup(s));
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FileAttributes fa;
                        DataRow dr = null;
                        try
                        {
                            dr = dt.Rows[i];
                            if (dr.RowState != DataRowState.Deleted)
                            {
                                ListViewItem lvi = new ListViewItem();
                                if (dr[1].ToString().Equals("True"))
                                {
                                    lvi.Checked = true;
                                }
                                else
                                {
                                    lvi.Checked = false;
                                }
                                lvi.SubItems.Add(dr[2].ToString());
                                lvi.SubItems.Add(dr[3].ToString());
                                lvi.SubItems.Add(dr[4].ToString());
                                lvi.SubItems.Add(dr[5].ToString());

                                fa = System.IO.File.GetAttributes(dr[4].ToString());
                                if (fa == FileAttributes.Directory)
                                {
                                    imageList1.Images.Add(Get.icon(dr[4].ToString(), Get.FileIconSize.Small, true));
                                }
                                else
                                {
                                    imageList1.Images.Add(Get.icon(dr[4].ToString(), Get.FileIconSize.Small, false));
                                }
                                lvi.ImageIndex = imgCount;
                                imgCount++;
                                lvList.SmallImageList = imageList1;

                                foreach (ListViewGroup group in lvList.Groups)
                                {
                                    if (group.Header.Equals(dr[0].ToString()))
                                    {
                                        lvi.Group = group;
                                    }
                                }
                                lvList.Items.Add(lvi);
                            }
                        }
                        catch (Exception ex) { fileNotFoundPaths.Add(dr[4].ToString()); }
                    }
                }
                checkGroups();
                JumpListMakerSharp.Properties.Settings.Default.saveFile = ofdLoad.FileName;
                this.Text = "JumpListMakerSharp - " + JumpListMakerSharp.Properties.Settings.Default.saveFile;
                JumpListMakerSharp.Properties.Settings.Default.needSave = false;
                purgeOld(ofdLoad.FileName);
            }
            else
            {
                return;
            }
        }

        private void purgeOld(string path)
        {
            if (fileNotFoundPaths.Count > 0)
            {
                DialogResult res = MessageBox.Show("One or more items have been deleted, would you like to remove them from the list?",
                    "Error:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    foreach (string s in fileNotFoundPaths)
                    {
                        XmlNode element = doc.SelectSingleNode("JumpList/Element[Path='" + s + "']");
                        doc.DocumentElement.RemoveChild(element);
                        try
                        {
                            System.IO.File.Delete(Path.Combine(workDir, element["Name"].InnerText + ".ico"));
                        }
                        catch (Exception ex) { }
                    }
                    doc.Save(path);
                    MessageBox.Show("Removed elements: " + fileNotFoundPaths.Count, "Info:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fileNotFoundPaths.Clear();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void save()
        {
            try
            {
                DataSet ds = new DataSet("JumpList");
                DataTable dt = new DataTable("Element");
                dt.Columns.Add("Category", System.Type.GetType("System.String"));
                dt.Columns.Add("Active", System.Type.GetType("System.String"));
                dt.Columns.Add("Name", System.Type.GetType("System.String"));
                dt.Columns.Add("Tooltip", System.Type.GetType("System.String"));
                dt.Columns.Add("Path", System.Type.GetType("System.String"));
                dt.Columns.Add("Arguments", System.Type.GetType("System.String"));
                ds.Tables.Add(dt);
                for (int count = 0; count < lvList.Items.Count; count++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = lvList.Items[count].Group.Header;
                    if (lvList.Items[count].Checked == true)
                    {
                        dr[1] = "True";
                    }
                    else
                    {
                        dr[1] = "False";
                    }
                    dr[2] = lvList.Items[count].SubItems[1].Text;
                    dr[3] = lvList.Items[count].SubItems[2].Text;
                    dr[4] = lvList.Items[count].SubItems[3].Text;
                    dr[5] = lvList.Items[count].SubItems[4].Text;
                    dt.Rows.Add(dr);
                }
                ds.Tables[0].WriteXml(JumpListMakerSharp.Properties.Settings.Default.saveFile);
                this.Text = "JumpListMakerSharp - " + JumpListMakerSharp.Properties.Settings.Default.saveFile;
                JumpListMakerSharp.Properties.Settings.Default.needSave = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            sfdSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfdSave.FileName = JumpListMakerSharp.Properties.Settings.Default.saveFile;
            DialogResult result = sfdSave.ShowDialog();
            JumpListMakerSharp.Properties.Settings.Default.saveFile = sfdSave.FileName;
            if ((sfdSave.FileName.Length != 0) && (result == DialogResult.OK))
            {
                save();
            }
        }

        private void tsmSaveFile_Click(object sender, EventArgs e)
        {
            save();
        }

        #endregion

        private void lvList_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                hitinfo = lvList.HitTest(e.X, e.Y);
                editbox.Bounds = hitinfo.SubItem.Bounds;
                editbox.Text = hitinfo.SubItem.Text;
                editbox.Focus();
                editbox.Show();
            }
        }

        private void editbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                hitinfo.SubItem.Text = editbox.Text;
                editbox.Hide();
                JumpListMakerSharp.Properties.Settings.Default.needSave = true;
                tsmSave.Enabled = true;
                tsmSaveFile.Enabled = true;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JumpListMakerSharp.Properties.Settings.Default.needSave == true)
            {
                if (DialogResult.Yes != MessageBox.Show(
                "Current JumpList has not been saved!",
                "Close without saving?",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button2))
                {
                    e.Cancel = true;
                }
            }
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            string longVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            int d1 = longVersion.IndexOf(".", 0);
            int d2 = longVersion.IndexOf(".", d1 + 1);
            int d3 = longVersion.IndexOf(".", d2 + 1);
            string version = "Version " + longVersion.Substring(0, d2) + "\n";
            string build = "Build " + longVersion.Substring(d2 + 1, d3 - d2 - 1) + "\n";
            string rev = "Revision " + longVersion.Substring(d3 + 1);
            MessageBox.Show(version + build + rev, "JumpListMakerSharp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdAddFile_Click(object sender, EventArgs e)
        {
            dr = ofdChoose.ShowDialog();
            setPath(dr, false);
        }

        private void cmdFolder_Click(object sender, EventArgs e)
        {
            dr = fbdFolder.ShowDialog();
            setPath(dr, true);
        }

        private void setPath(DialogResult result, bool isDirectory)
        {
            try
            {
                if (isDirectory == true)
                {
                    if (result == DialogResult.OK)
                    {
                        if (fbdFolder.SelectedPath != "")
                        {
                            txtName.Text = Path.GetFileName(fbdFolder.SelectedPath);
                            txtPath.Text = fbdFolder.SelectedPath;
                            System.Drawing.Icon ico = JumpListMakerSharp.Get.FolderIcon(txtPath.Text, Get.FileIconSize.Small);
                            using (var save = new FileStream(Path.Combine(workDir, txtName.Text) + ".ico", FileMode.CreateNew))
                            {
                                ico.ToBitmap().Save(save, System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (result == DialogResult.OK)
                    {
                        if (ofdChoose.FileName != "")
                        {
                            txtName.Text = Path.GetFileNameWithoutExtension(ofdChoose.FileName);
                            txtPath.Text = ofdChoose.FileName;
                            System.Drawing.Icon ico = JumpListMakerSharp.Get.FileIcon(txtPath.Text, Get.FileIconSize.Small);
                            using (var save = new FileStream(Path.Combine(workDir, txtName.Text) + ".ico", FileMode.CreateNew))
                            {
                                ico.ToBitmap().Save(save, System.Drawing.Imaging.ImageFormat.Bmp);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void cmdAddTask_Click(object sender, EventArgs e)
        {
            addTask();
        }

        private void cmdSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lvList.SelectedItems[0];
                if (item != null)
                {
                    lvList.Items.Remove(item);
                    checkGroups();
                    lvList.Items.Add(item);
                    GroupItem(item);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lvList.Items.Count != 0)
            {
                foreach (ListViewItem eachItem in lvList.SelectedItems)
                {
                    ListViewGroup group = eachItem.Group;
                    lvList.Items.Remove(eachItem);
                    if (group.Items.Count == 0)
                    {
                        lvList.Groups.Remove(group);
                    }
                    try
                    {
                        System.IO.File.Delete(Path.Combine(workDir, eachItem.SubItems[1].Text + ".ico"));
                    }
                    catch (Exception ex) { }
                }
                checkGroups();
                JumpListMakerSharp.Properties.Settings.Default.needSave = true;
                tsmSaveFile.Enabled = true;
                tsmSave.Enabled = true;
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            resetText();
        }

        private void cmdJump_Click(object sender, EventArgs e)
        {
            tasks = new List<Task>();
            myjl = new JumpList();
            myjl.ShowFrequentCategory = false;
            myjl.ShowRecentCategory = false;
            myjl.JumpItems.Clear();
            myjl.Apply();

            foreach (ListViewItem item in lvList.Items)
            {
                if (item.Checked == true)
                {
                    tasks.Add(new Task(item.Group.Header, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text));
                }
            }

            foreach (Task t in tasks)
            {
                myjl.JumpItems.Add(t);
            }

            myjl.Apply();
        }

        private void cbActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (cbActivity.Checked == false)
            {
                txtCat.Text = "";
                cmbGroups.SelectedIndex = -1;
                txtCat.Enabled = true;
                cmbGroups.Enabled = true;
            }
            else
            {
                txtCat.Text = "";
                cmbGroups.SelectedIndex = -1;
                txtCat.Enabled = false;
                cmbGroups.Enabled = false;
            }
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCat.Text = cmbGroups.Text;
        }

        private void lvList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            JumpListMakerSharp.Properties.Settings.Default.needSave = true;
            tsmSave.Enabled = true;
            tsmSaveFile.Enabled = true;
        }
    }
}