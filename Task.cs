using System;
using System.IO;
using System.Windows.Shell;

namespace JumpListMakerSharp
{
    class Task : JumpTask
    {

        public Task(string cat, string name, string tooltip, string path, string args)
            : base()
        {
            this.CustomCategory = cat;
            this.Title = name;
            this.Description = tooltip;
            this.ApplicationPath = path;
            this.Arguments = args;
            this.IconResourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JumpListMakerSharp", name + ".ico");
        }
    }
}
