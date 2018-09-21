using System.ComponentModel;
using System.Windows.Forms;

namespace MattLamp.Controls
{
    [Designer(typeof(OwnerDrawPanel), typeof(Panel))]
    [DesignTimeVisible(true)]
    internal class OwnerDrawPanel : Panel
    {
        public OwnerDrawPanel() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;
        }
    }
}
