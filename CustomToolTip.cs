using System.Windows.Forms;

namespace JumpListMakerSharp
{
    class CustomToolTip : ToolTip
    {
        public CustomToolTip(Control c, string tooltip) : base()
        {
            AutoPopDelay = 2000;
            InitialDelay = 500;
            ReshowDelay = 500;
            ShowAlways = true;
            SetToolTip(c, tooltip);
        }
    }
}
