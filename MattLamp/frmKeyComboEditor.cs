using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MattLamp.Models;

namespace MattLamp
{
    public partial class frmKeyComboEditor : Form
    {
        public frmKeyComboEditor()
        {
            InitializeComponent();
            cbKeyCode.DataSource = QuantumKeyTable.GetKeys().ToList();
        }

        public KeyCombo Combo
        {
            get
            {
                var key = cbKeyCode.SelectedItem as Key;
                if (key != null)
                {
                    var mods = (chkModLCtrl.Checked ? Modifiers.LCTRL : 0)
                        | (chkModLShift.Checked ? Modifiers.LSHIFT : 0)
                        | (chkModLAlt.Checked ? Modifiers.LALT : 0)
                        | (chkModLGUI.Checked ? Modifiers.LGUI : 0)
                        | (chkModRCtrl.Checked ? Modifiers.RCTRL : 0)
                        | (chkModRShift.Checked ? Modifiers.RSHIFT : 0)
                        | (chkModRAlt.Checked ? Modifiers.RALT : 0)
                        | (chkModRGUI.Checked ? Modifiers.RGUI : 0);
                    return new KeyCombo(key.KeyCode, mods);
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    chkModLCtrl.Checked = value.Modifier.HasFlag(Modifiers.LCTRL);
                    chkModLShift.Checked = value.Modifier.HasFlag(Modifiers.LSHIFT);
                    chkModLAlt.Checked = value.Modifier.HasFlag(Modifiers.LALT);
                    chkModLGUI.Checked = value.Modifier.HasFlag(Modifiers.LGUI);
                    chkModRCtrl.Checked = value.Modifier.HasFlag(Modifiers.RCTRL);
                    chkModRShift.Checked = value.Modifier.HasFlag(Modifiers.RSHIFT);
                    chkModRAlt.Checked = value.Modifier.HasFlag(Modifiers.RALT);
                    chkModRGUI.Checked = value.Modifier.HasFlag(Modifiers.RGUI);
                    cbKeyCode.SelectedItem = QuantumKeyTable.GetKey(value.KeyCode);
                }
                else
                {
                    chkModLCtrl.Checked = chkModLShift.Checked = chkModLAlt.Checked = chkModLGUI.Checked = chkModRCtrl.Checked = chkModRShift.Checked = chkModRAlt.Checked = chkModRGUI.Checked = false;
                    cbKeyCode.SelectedIndex = 0;
                }
            }
        }
    }
}
