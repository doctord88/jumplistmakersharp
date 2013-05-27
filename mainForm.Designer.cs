namespace JumpListMakerSharp
{
    partial class mainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.itemmenubar = new System.Windows.Forms.MenuStrip();
            this.itemfile = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdChoose = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbActivity = new System.Windows.Forms.CheckBox();
            this.cmdJump = new System.Windows.Forms.Button();
            this.cmdSwitch = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmdAddFile = new System.Windows.Forms.Button();
            this.cmdFolder = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTooltip = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdAddTask = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvList = new JumpListMakerSharp.ListViewEx();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemmenubar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemmenubar
            // 
            this.itemmenubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemfile,
            this.tsmAbout});
            this.itemmenubar.Location = new System.Drawing.Point(0, 0);
            this.itemmenubar.Name = "itemmenubar";
            this.itemmenubar.Size = new System.Drawing.Size(1481, 24);
            this.itemmenubar.TabIndex = 1;
            // 
            // itemfile
            // 
            this.itemfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.tsmSaveFile,
            this.tsmSave});
            this.itemfile.Name = "itemfile";
            this.itemfile.Size = new System.Drawing.Size(37, 20);
            this.itemfile.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // tsmSaveFile
            // 
            this.tsmSaveFile.Name = "tsmSaveFile";
            this.tsmSaveFile.Size = new System.Drawing.Size(123, 22);
            this.tsmSaveFile.Text = "Save";
            this.tsmSaveFile.Click += new System.EventHandler(this.tsmSaveFile_Click);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(123, 22);
            this.tsmSave.Text = "Save As...";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(52, 20);
            this.tsmAbout.Text = "About";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "jlxml";
            this.sfdSave.Filter = "JumpList XML File (*.jlxml)|*.jlxml";
            // 
            // fbdFolder
            // 
            this.fbdFolder.RootFolder = System.Environment.SpecialFolder.LocalizedResources;
            // 
            // ofdLoad
            // 
            this.ofdLoad.DefaultExt = "jlxml";
            this.ofdLoad.Filter = "JumpList XML File (*.jlxml)|*.jlxml";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lvList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1481, 601);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbActivity);
            this.groupBox1.Controls.Add(this.cmdJump);
            this.groupBox1.Controls.Add(this.cmdSwitch);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmdClear);
            this.groupBox1.Controls.Add(this.cmdDelete);
            this.groupBox1.Controls.Add(this.cmdAddTask);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1475, 205);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // cbActivity
            // 
            this.cbActivity.AutoSize = true;
            this.cbActivity.Location = new System.Drawing.Point(451, 72);
            this.cbActivity.Name = "cbActivity";
            this.cbActivity.Size = new System.Drawing.Size(174, 17);
            this.cbActivity.TabIndex = 31;
            this.cbActivity.Text = "Create a tasklist (no categories)";
            this.cbActivity.UseVisualStyleBackColor = true;
            this.cbActivity.CheckedChanged += new System.EventHandler(this.cbActivity_CheckedChanged);
            // 
            // cmdJump
            // 
            this.cmdJump.Location = new System.Drawing.Point(826, 65);
            this.cmdJump.Name = "cmdJump";
            this.cmdJump.Size = new System.Drawing.Size(89, 79);
            this.cmdJump.TabIndex = 30;
            this.cmdJump.Text = "Set JumpList";
            this.cmdJump.UseVisualStyleBackColor = true;
            this.cmdJump.Click += new System.EventHandler(this.cmdJump_Click);
            // 
            // cmdSwitch
            // 
            this.cmdSwitch.Location = new System.Drawing.Point(735, 19);
            this.cmdSwitch.Name = "cmdSwitch";
            this.cmdSwitch.Size = new System.Drawing.Size(66, 79);
            this.cmdSwitch.TabIndex = 28;
            this.cmdSwitch.Text = "Switch Category";
            this.cmdSwitch.UseVisualStyleBackColor = true;
            this.cmdSwitch.Click += new System.EventHandler(this.cmdSwitch_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPath);
            this.groupBox6.Controls.Add(this.cmdAddFile);
            this.groupBox6.Controls.Add(this.cmdFolder);
            this.groupBox6.Location = new System.Drawing.Point(9, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 81);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(6, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(416, 20);
            this.txtPath.TabIndex = 10;
            // 
            // cmdAddFile
            // 
            this.cmdAddFile.Location = new System.Drawing.Point(6, 46);
            this.cmdAddFile.Name = "cmdAddFile";
            this.cmdAddFile.Size = new System.Drawing.Size(198, 28);
            this.cmdAddFile.TabIndex = 13;
            this.cmdAddFile.Text = "Add File";
            this.cmdAddFile.UseVisualStyleBackColor = true;
            this.cmdAddFile.Click += new System.EventHandler(this.cmdAddFile_Click);
            // 
            // cmdFolder
            // 
            this.cmdFolder.Location = new System.Drawing.Point(224, 46);
            this.cmdFolder.Name = "cmdFolder";
            this.cmdFolder.Size = new System.Drawing.Size(198, 28);
            this.cmdFolder.TabIndex = 14;
            this.cmdFolder.Text = "Add Folder";
            this.cmdFolder.UseVisualStyleBackColor = true;
            this.cmdFolder.Click += new System.EventHandler(this.cmdFolder_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtArgs);
            this.groupBox5.Location = new System.Drawing.Point(445, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(212, 50);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Arguments";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(6, 20);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(198, 20);
            this.txtArgs.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTooltip);
            this.groupBox4.Location = new System.Drawing.Point(445, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 79);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tooltip";
            // 
            // txtTooltip
            // 
            this.txtTooltip.Location = new System.Drawing.Point(6, 34);
            this.txtTooltip.Name = "txtTooltip";
            this.txtTooltip.Size = new System.Drawing.Size(198, 20);
            this.txtTooltip.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Location = new System.Drawing.Point(227, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 79);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(198, 20);
            this.txtName.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCat);
            this.groupBox2.Controls.Add(this.cmbGroups);
            this.groupBox2.Location = new System.Drawing.Point(9, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 79);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Category";
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(6, 19);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(198, 20);
            this.txtCat.TabIndex = 7;
            // 
            // cmbGroups
            // 
            this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(6, 45);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(198, 21);
            this.cmbGroups.TabIndex = 20;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(735, 106);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(66, 79);
            this.cmdClear.TabIndex = 22;
            this.cmdClear.Text = "Clear Fields";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(663, 106);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(66, 79);
            this.cmdDelete.TabIndex = 18;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAddTask
            // 
            this.cmdAddTask.Location = new System.Drawing.Point(663, 19);
            this.cmdAddTask.Name = "cmdAddTask";
            this.cmdAddTask.Size = new System.Drawing.Size(66, 79);
            this.cmdAddTask.TabIndex = 12;
            this.cmdAddTask.Text = "Add";
            this.cmdAddTask.UseVisualStyleBackColor = true;
            this.cmdAddTask.Click += new System.EventHandler(this.cmdAddTask_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvList
            // 
            this.lvList.AllowDrop = true;
            this.lvList.AllowRowReorder = true;
            this.lvList.AutoArrange = false;
            this.lvList.CheckBoxes = true;
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvList.FullRowSelect = true;
            this.lvList.Location = new System.Drawing.Point(3, 3);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(1475, 384);
            this.lvList.SmallImageList = this.imageList1;
            this.lvList.TabIndex = 19;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvList_ItemChecked);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Active";
            this.columnHeader6.Width = 42;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 167;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tooltip";
            this.columnHeader8.Width = 297;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Path";
            this.columnHeader9.Width = 657;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Arguments";
            this.columnHeader10.Width = 193;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1481, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.itemmenubar);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JumpListMakerSharp";
            this.itemmenubar.ResumeLayout(false);
            this.itemmenubar.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip itemmenubar;
        private System.Windows.Forms.ToolStripMenuItem itemfile;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.OpenFileDialog ofdChoose;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbActivity;
        private System.Windows.Forms.Button cmdJump;
        private System.Windows.Forms.Button cmdSwitch;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdAddFile;
        private System.Windows.Forms.Button cmdFolder;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTooltip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAddTask;
        private JumpListMakerSharp.ListViewEx lvList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ImageList imageList1;
    }
}

