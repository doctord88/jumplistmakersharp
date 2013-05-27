using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;

namespace JumpListMakerSharp
{
    public static class Get
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_DISPLAYNAME = 0x200;
        public const uint SHGFI_TYPENAME = 0x400;
        public const uint SHGFI_ATTRIBUTES = 0x800;
        public const uint SHGFI_ICONLOCATION = 0x1000;
        public const uint SHGFI_EXETYPE = 0x2000;
        public const uint SHGFI_SYSICONINDEX = 0x4000;
        public const uint SHGFI_LINKOVERLAY = 0x8000;
        public const uint SHGFI_SELECTED = 0x10000;
        public const uint SHGFI_LARGEICON = 0x0;
        public const uint SHGFI_SMALLICON = 0x1;
        public const uint SHGFI_OPENICON = 0x2;
        public const uint SHGFI_SHELLICONSIZE = 0x4;
        public const uint SHGFI_PIDL = 0x8;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x10;

        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;

        [DllImport("comctl32.dll")]
        private static extern int ImageList_GetImageCount(int himl);

        [DllImport("comctl32.dll")]
        private static extern int ImageList_GetIcon(int HIMAGELIST, int ImgIndex, int hbmMask);

        [DllImport("shell32.dll")]
        private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbfileInfo, uint uFlags);

        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        }

        public enum FileIconSize
        {
            Small,    // 16x16 pixels
            Large    // 32x32 pixels
        }

        // get a 32x32 icon for a given file

        public static Image FileIconAsImage(string fullpath)
        {
            return FileIconAsImage(fullpath, FileIconSize.Large);
        }

        public static Image FileIconAsImage(string fullpath, FileIconSize size)
        {
            SHFILEINFO info = new SHFILEINFO();

            uint flags = SHGFI_USEFILEATTRIBUTES | SHGFI_ICON;
            if (size == FileIconSize.Small)
            {
                flags |= SHGFI_SMALLICON;
            }

            int retval = SHGetFileInfo(fullpath, FILE_ATTRIBUTE_NORMAL, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            if (retval == 0)
            {
                return null;  // error occured
            }

            System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon);

            //ImageList imglist = new ImageList();
            //imglist.ImageSize = icon.Size;
            //imglist.Images.Add(icon);

            //Image image = imglist.Images[0];
            //icon.Dispose();
            //return image;
            return icon.ToBitmap();
        }

        public static Icon FileIcon(string fullpath, FileIconSize size)
        {
            SHFILEINFO info = new SHFILEINFO();

            uint flags = SHGFI_USEFILEATTRIBUTES | SHGFI_ICON;
            if (size == FileIconSize.Small)
            {
                flags |= SHGFI_SMALLICON;
            }

            int retval = SHGetFileInfo(fullpath, FILE_ATTRIBUTE_NORMAL, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            if (retval == 0)
            {
                return null;  // error occured
            }

            System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon);
            return icon;
        }

        public static Icon FolderIcon(string fullPath, FileIconSize size)
        {
            SHFILEINFO info = new SHFILEINFO();

            uint flags = SHGFI_USEFILEATTRIBUTES | SHGFI_ICON;
            if (size == FileIconSize.Small)
            {
                flags |= SHGFI_SMALLICON;
            }

            int retval = SHGetFileInfo(fullPath, FILE_ATTRIBUTE_DIRECTORY, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            if (retval == 0)
            {
                return null;  // error occured
            }

            System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon);
            return icon;
        }

        public static Icon icon(string fullPath, FileIconSize size, bool isFolder)
        {
            if (isFolder)
            {
                return FolderIcon(fullPath, size);
            }
            else
            {
                return FileIcon(fullPath, size);
            }
        }

        public static int FileIconIndex(string fullpath, FileIconSize size)
        {
            SHFILEINFO info = new SHFILEINFO();

            uint flags = SHGFI_USEFILEATTRIBUTES | SHGFI_SYSICONINDEX;
            if (size == FileIconSize.Small)
            {
                flags |= SHGFI_SMALLICON;
            }

            int retval = SHGetFileInfo(fullpath, FILE_ATTRIBUTE_NORMAL, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            if (retval == 0)
            {
                return -1;  // error
            }

            return info.iIcon;
        }

        public static int FolderIconIndex(string fullpath, FileIconSize size)
        {
            SHFILEINFO info = new SHFILEINFO();

            uint flags = SHGFI_USEFILEATTRIBUTES | SHGFI_SYSICONINDEX;
            if (size == FileIconSize.Small)
            {
                flags |= SHGFI_SMALLICON;
            }

            int retval = SHGetFileInfo(fullpath, FILE_ATTRIBUTE_DIRECTORY, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            if (retval == 0)
            {
                return -1;  // error
            }

            return info.iIcon;
        }

        public static void UpdateSystemImageList(ImageList imageList, FileIconSize size, bool isSelected, Image deletedImage)
        {
            SHFILEINFO info = new SHFILEINFO();
            uint flags = SHGFI_SYSICONINDEX;

            if (size == FileIconSize.Small)
                flags |= SHGFI_SMALLICON;

            if (isSelected == true)
                flags |= SHGFI_OPENICON;

            int imageHandle = SHGetFileInfo("C:\\", 0, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), flags);
            int iconCount = ImageList_GetImageCount(imageHandle);
            for (int i = imageList.Images.Count; i < iconCount; i++)
            {

                IntPtr iconHandle = (IntPtr)ImageList_GetIcon(imageHandle, i, 0);
                try
                {
                    if (iconHandle.ToInt64() != 0)
                    {
                        Icon icon = Icon.FromHandle(iconHandle);
                        imageList.Images.Add(icon);
                        icon.Dispose();
                        DestroyIcon(iconHandle);
                    }
                }
                catch
                {
                    imageList.Images.Add(deletedImage);
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public extern static int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        extern static void mciSendStringA(string lpstrCommand, string lpstrReturnString, long uReturnLength, long hwndCallback);
    }
}
