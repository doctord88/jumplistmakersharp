using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JumpListMakerSharp
{
    static class Program
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;

            switch (osInfo.Version.Major)
            {
                case 6:

                    switch (osInfo.Version.Minor)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 0:
                            MessageBox.Show("Operating system not supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    break;

                default:
                    MessageBox.Show("Operating system not supported!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            string icodir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JumpListMakerSharp");
            if (!Directory.Exists(icodir))
            {
                Directory.CreateDirectory(icodir);
            }

            if (!isAssociated())
            {
                associate();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new mainForm());
            }
            else
            {
                Application.Run(new mainForm(args[0]));
            }
        }

        public static bool isAssociated()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.jlxml", false) == null);
        }

        public static void associate()
        {
            RegistryKey fileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.jlxml");
            RegistryKey appReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\JumpListMakerSharp.exe");
            RegistryKey appAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.jlxml");
            fileReg.CreateSubKey("DefaultIcon").SetValue("", JumpListMakerSharp.Properties.Resources.icon);
            fileReg.CreateSubKey("PerceivedType").SetValue("", "XML");
            appReg.CreateSubKey("Shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
            appReg.CreateSubKey("Shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
            appReg.CreateSubKey("DefaultIcon").SetValue("", JumpListMakerSharp.Properties.Resources.icon);
            appAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Application\\JumpListMakerSharp");
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
