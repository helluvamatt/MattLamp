using MattLamp.Common;
using MattLamp.Config;
using MattLamp.Controls;
using MattLamp.Models;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MattLamp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            ledEffectModeBindingSource.DataSource = LedEffectMode.Modes.ToList();
            cbActionSetLedModeParm.DataSource = LedEffectMode.Modes.ToList();
            cbActionToggleLedModeParm1.DataSource = LedEffectMode.Modes.ToList();
            cbActionToggleLedModeParm2.DataSource = LedEffectMode.Modes.ToList();

            var customColors = ConfigurationManager.GetSection("colors") as CustomColorCollection;
            if (customColors != null) dlgColorPicker.CustomColors = customColors.Colors.Take(16).Reverse().Select(cc => CustomColorToBGR(cc)).ToArray();

            _KeyComboHolder = new ObjectHolder<KeyCombo>("Not set");
            _KeyComboHolder.PropertyChanged += _KeyComboHolder_PropertyChanged;

            CheckEmptyDeviceList();

            _DeviceManager = new DeviceManager();
            _DeviceManager.DeviceAdded += DeviceManager_DeviceAdded;
            _DeviceManager.DeviceRemoved += DeviceManager_DeviceRemoved;
            _DeviceManager.DeviceReady += DeviceManager_DeviceReady;
            _DeviceManager.LedStatusReceived += DeviceManager_LedStatusReceived;
            _DeviceManager.KeyConfigReceived += DeviceManager_KeyConfigReceived;
            _DeviceManager.LedConfigReceived += DeviceManager_LedConfigReceived;
            _DeviceManager.Init();
        }

        #region Statics

        private static readonly ColorBlend RAINBOW_BLEND = new ColorBlend()
        {
            Colors = new Color[]
            {
                Color.FromArgb(0xFF, 0, 0),
                Color.FromArgb(0xFF, 0xFF, 0),
                Color.FromArgb(0, 0xFF, 0),
                Color.FromArgb(0, 0xFF, 0xFF),
                Color.FromArgb(0, 0, 0xFF),
                Color.FromArgb(0xFF, 0, 0xFF),
                Color.FromArgb(0xFF, 0, 0),
            },
            Positions = new float[]
            {
                0.0f,
                0.1666666667f,
                0.3333333333f,
                0.5f,
                0.6666666667f,
                0.8333333333f,
                1.0f
            },
        };

        #endregion

        #region Variables

        private DeviceManager _DeviceManager;

        private readonly ObjectHolder<KeyCombo> _KeyComboHolder;

        private bool IsDeviceConnected => _DeviceManager != null && _DeviceManager.IsDeviceConnected;
        
        #endregion

        #region Device selection

        private void DeviceManager_DeviceRemoved(object sender, DeviceEventArgs e)
        {
            Invoke(() =>
            {
                deviceBindingSource.Remove(e.Device);
                CheckEmptyDeviceList();
            });
        }

        private void DeviceManager_DeviceAdded(object sender, DeviceEventArgs e)
        {
            Invoke(() => {
                deviceBindingSource.Add(e.Device);
                CheckEmptyDeviceList();
                deviceBindingSource.ResetCurrentItem();
            });
        }

        private void DeviceManager_DeviceReady(object sender, DeviceReadyEventArgs e)
        {
            Invoke(() =>
            {
                ledStatusBindingSource.CurrencyManager.SuspendBinding();
                ledStatusBindingSource.Clear();
                
                for (int i = 0; i < e.DeviceReportedLedCount && i < e.Device.DeviceClass.Leds.Count; i++)
                {
                    var deviceLed = e.Device.DeviceClass.Leds.Leds[i];
                    var led = new LedStatus(deviceLed.X, deviceLed.Y, deviceLed.Size);
                    ledStatusBindingSource.Add(led);
                }
                ledStatusBindingSource.CurrencyManager.ResumeBinding();
            });
        }

        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDevice.SelectedIndex < 0)
            {
                SetSelectedDevice(null);
            }
            else
            {
                SetSelectedDevice(deviceBindingSource[cbDevice.SelectedIndex] as DeviceInstance);
            }
        }

        private void CheckEmptyDeviceList()
        {
            if (deviceBindingSource.Count == 0)
            {
                lblNoDevices.Visible = true;
                cbDevice.Visible = false;
            }
            else
            {
                lblNoDevices.Visible = false;
                cbDevice.Visible = true;
            }
        }

        private void SetSelectedDevice(DeviceInstance device)
        {
            rbActionNone.Enabled =
                rbActionCycleLedMode.Enabled =
                rbActionSendKeyCombo.Enabled =
                rbActionSetLedMode.Enabled =
                rbActionToggleLedMode.Enabled =
                cbLedMode.Enabled =
                lbEffectColors.Enabled =
                btnLedRemoveColor.Enabled =
                btnLedClearColors.Enabled =
                ledLayoutControl.Enabled =
                btnSaveKeyConfig.Enabled =
                btnSaveLedConfig.Enabled =
                tbEffectSpeed.Enabled =
                tbStrobeSpeed.Enabled =
                device != null;
            
            if (device == null)
            {
                _KeyComboHolder.Object = null;

                btnLedClearColors_Click(this, EventArgs.Empty);

                ledStatusBindingSource.Clear();

                rbActionNone.Checked = true;
            }

            // Fetch config from device
            _DeviceManager.SetActiveDevice(device);
        }

        #endregion

        #region Key Combinations

        private void DeviceManager_KeyConfigReceived(object sender, KeyConfigReceivedEventArgs e)
        {
            Invoke(() =>
            {
                switch (e.KeyConfig.Action)
                {
                    case KeyPressAction.LedStep:
                        rbActionCycleLedMode.Checked = true;
                        break;
                    case KeyPressAction.KeyCombo:
                        rbActionSendKeyCombo.Checked = true;
                        _KeyComboHolder.Object = e.KeyConfig.CreateKeyCombo();
                        break;
                    case KeyPressAction.LedSet:
                        rbActionSetLedMode.Checked = true;
                        cbActionSetLedModeParm.SelectedIndex = e.KeyConfig.Param1;
                        break;
                    case KeyPressAction.LedToggle:
                        rbActionToggleLedMode.Checked = true;
                        cbActionToggleLedModeParm1.SelectedIndex = e.KeyConfig.Param1;
                        cbActionToggleLedModeParm2.SelectedIndex = e.KeyConfig.Param2;
                        break;
                    case KeyPressAction.None:
                    default:
                        rbActionNone.Checked = true;
                        break;
                }
            });
        }

        private void _KeyComboHolder_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ObjToString")
            {
                lblKeyComboDisp.Text = _KeyComboHolder.ObjToString;
                lblKeyComboDisp.Font = new Font(lblKeyComboDisp.Font, _KeyComboHolder.Object == null ? FontStyle.Italic : FontStyle.Regular);
            }
        }

        private void rbActionSetLedMode_CheckedChanged(object sender, EventArgs e)
        {
            cbActionSetLedModeParm.Enabled = rbActionSetLedMode.Checked;
        }

        private void rbActionToggleLedMode_CheckedChanged(object sender, EventArgs e)
        {
            cbActionToggleLedModeParm1.Enabled = cbActionToggleLedModeParm2.Enabled = rbActionToggleLedMode.Checked;
        }

        private void rbActionSendKeyCombo_CheckedChanged(object sender, EventArgs e)
        {
            btnSetKeyCombo.Enabled = rbActionSendKeyCombo.Checked;
        }

        private void btnSetKeyCombo_Click(object sender, EventArgs e)
        {
            var dlg = new frmKeyComboEditor();
            dlg.Combo = _KeyComboHolder.Object;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _KeyComboHolder.Object = dlg.Combo;
            }
        }

        private void btnSaveKeyConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Properties.Resources.ConfirmSaveKey, Properties.Resources.ConfirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rbActionCycleLedMode.Checked)
                {
                    _DeviceManager.SetKeyConfig(new KeyConfig(KeyPressAction.LedStep, null));
                }
                else if (rbActionSendKeyCombo.Checked)
                {
                    if (_KeyComboHolder.Object != null)
                    {
                        _DeviceManager.SetKeyConfig(new KeyConfig(KeyPressAction.KeyCombo, _KeyComboHolder.Object));
                    }
                    else
                    {
                        MessageBox.Show(this, "You must set a key combination to send.", "Set a key combo...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (rbActionSetLedMode.Checked)
                {
                    _DeviceManager.SetKeyConfig(new KeyConfig(KeyPressAction.LedSet, (byte)cbActionSetLedModeParm.SelectedIndex));
                }
                else if (rbActionToggleLedMode.Checked)
                {
                    _DeviceManager.SetKeyConfig(new KeyConfig(KeyPressAction.LedToggle, (byte)cbActionToggleLedModeParm1.SelectedIndex, (byte)cbActionToggleLedModeParm2.SelectedIndex));
                }
                else
                {
                    _DeviceManager.SetKeyConfig(new KeyConfig(KeyPressAction.None, null));
                }
            }
        }

        #endregion

        #region LEDs

        #region Mode

        private void cbLedMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLedMode.SelectedIndex != 1) tbColorVal.Value = 0;
            ledLayoutControl.Enabled = rbLiveModeHB.Enabled = rbLiveModeTemp.Enabled = IsDeviceConnected && cbLedMode.SelectedIndex == 1; // Live
            // Make sure dependant controls get updated
            rbLiveMode_CheckedChanged(sender, e);
            SendLedConfig();
        }

        private void cbLedMode_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (ledEffectModeBindingSource == null) return;
            if (e.Index < 0 || e.Index >= ledEffectModeBindingSource.Count) return;
            var measuredX = ledEffectModeBindingSource.Cast<LedEffectMode>().Max(lem => e.Graphics.MeasureString(lem.Name, e.Font).Width);
            var thisItem = ledEffectModeBindingSource[e.Index] as LedEffectMode;
            e.DrawBackground();
            e.Graphics.DrawString(thisItem.Name, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y);
            var iFont = new Font(e.Font, FontStyle.Italic);
            e.Graphics.DrawString(thisItem.Description, iFont, new SolidBrush(e.ForeColor), e.Bounds.X + 2 + measuredX, e.Bounds.Y);
            e.DrawFocusRectangle();
        }

        #endregion

        #region Colors

        private void btnLedAddColor_Click(object sender, EventArgs e)
        {
            if (colorBindingSource.Count < 8)
            {
                if (dlgColorPicker.ShowDialog(this) == DialogResult.OK)
                {
                    colorBindingSource.Add(dlgColorPicker.Color);
                }
            }
        }

        private void btnLedRemoveColor_Click(object sender, EventArgs e)
        {
            colorBindingSource.RemoveCurrent();
        }

        private void btnLedClearColors_Click(object sender, EventArgs e)
        {
            colorBindingSource.Clear();
        }

        private void lbEffectColors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbEffectColors.IndexFromPoint(e.Location);
            if (index >= 0 && index < colorBindingSource.Count)
            {
                dlgColorPicker.Color = (Color)colorBindingSource[index];
                if (dlgColorPicker.ShowDialog(this) == DialogResult.OK)
                {
                    colorBindingSource[index] = dlgColorPicker.Color;
                }
            }
        }

        private void colorBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnLedAddColor.Enabled = IsDeviceConnected && colorBindingSource.Count < 8; // Max: 8 colors
            SendLedConfig();
        }

        private void lbEffectColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (colorBindingSource == null) return;
            if (e.Index < 0 || e.Index >= colorBindingSource.Count) return;
            var color = (Color)colorBindingSource[e.Index];
            e.DrawBackground();
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Height - 2, e.Bounds.Height - 2);
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Height - 2.5f, e.Bounds.Height - 2.5f);
            e.Graphics.DrawString(string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X + e.Bounds.Height + 2, e.Bounds.Y + 2);
            e.DrawFocusRectangle();
        }

        #endregion

        #region LED status

        private void DeviceManager_LedStatusReceived(object sender, LedStatusReceivedEventArgs e)
        {
            Invoke(() =>
            {
                for (int i = 0; i < e.LedStatus.Count && i < ledStatusBindingSource.Count; i++)
                {
                    var led = ledStatusBindingSource[i] as LedStatus;
                    if (led != null) led.Color = e.LedStatus[i];
                }
            });
        }

        private void ledLayoutControl_StatusTextChanged(object sender, StatusTextChangedEventArgs e)
        {
            lblLedStatus.Text = e.StatusText;
        }

        private void ledLayoutControl_OnItemRightClick(object sender, LedStatusEventArgs e)
        {
            var menu = new ContextMenuStrip();

            if (btnLedAddColor.Enabled)
            {
                var addColorItem = new ToolStripMenuItem($"Add {e.Led} to effect colors", Properties.Resources.add, (s, a) => { if (colorBindingSource.Count < 8) colorBindingSource.Add(e.Led.ToColor()); });
                menu.Items.Add(addColorItem);
            }

            // TODO Maybe more items?

            if (menu.Items.Count > 0) menu.Show(ledLayoutControl, e.Location);
        }

        #endregion

        #region Live Mode

        private void rectColorVal_Paint(object sender, PaintEventArgs e)
        {
            var bar = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + 12, e.ClipRectangle.Width, e.ClipRectangle.Height - 24);
            var brush = new LinearGradientBrush(bar, Color.Transparent, Color.Transparent, 270.0f);
            brush.InterpolationColors = new ColorBlend() {
                Colors = new Color[]
                {
                    Color.Black,
                    ColorUtils.FromHSB(tbColorHue.Value, 1, 0.5f),
                    Color.White,
                },
                Positions = new float[] { 0, 0.5f, 1 }
            };
            e.Graphics.FillRectangle(brush, new Rectangle(bar.X, bar.Y + 1, bar.Width, bar.Height - 1));

        }

        private void rectColorHue_Paint(object sender, PaintEventArgs e)
        {
            var bar = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + 12, e.ClipRectangle.Width, e.ClipRectangle.Height - 24);
            var brush = new LinearGradientBrush(bar, Color.Transparent, Color.Transparent, 270.0f);
            brush.InterpolationColors = RAINBOW_BLEND;
            e.Graphics.FillRectangle(brush, new Rectangle(bar.X, bar.Y + 1, bar.Width, bar.Height - 1));
        }

        private void rectColorTemp_Paint(object sender, PaintEventArgs e)
        {
            var bar = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + 12, e.ClipRectangle.Width, e.ClipRectangle.Height - 24);
            var brush = new LinearGradientBrush(bar, Color.Transparent, Color.Transparent /* ColorTemperature.TEMP_BLEND.Colors.First(), ColorTemperature.TEMP_BLEND.Colors.Last() */, 270.0f);
            brush.InterpolationColors = ColorTemperature.TEMP_BLEND;
            e.Graphics.FillRectangle(brush, new Rectangle(bar.X, bar.Y + 1, bar.Width, bar.Height - 1));
        }

        private void rbLiveMode_CheckedChanged(object sender, EventArgs e)
        {
            tbColorHue.Enabled = rectColorHue.Enabled = tbColorVal.Enabled = rectColorVal.Enabled = rbLiveModeHB.Enabled && rbLiveModeHB.Checked;
            tbColorTemp.Enabled = rectColorTemp.Enabled = rbLiveModeTemp.Enabled && rbLiveModeTemp.Checked;
            SetSelectedColor();
        }

        private void tbColorHue_ValueChanged(object sender, EventArgs e)
        {
            SetSelectedColor();
            rectColorVal.Invalidate();
        }

        private void tbColorVal_ValueChanged(object sender, EventArgs e)
        {
            SetSelectedColor();
        }

        private void tbColorTemp_ValueChanged(object sender, EventArgs e)
        {
            SetSelectedColor();
        }

        private void SetSelectedColor()
        {
            if (cbLedMode.SelectedIndex == 1) // Live mode
            {
                Color color;

                if (rbLiveModeHB.Checked) color = ColorUtils.FromHSB(tbColorHue.Value, 1, tbColorVal.Value / 100.0f);
                else color = ColorUtils.FromTemperatureK(tbColorTemp.Value);

                if (ledLayoutControl.IsAllSelected())
                {
                    _DeviceManager.SetLedAll(color);
                }
                else
                {
                    foreach (var i in ledLayoutControl.GetSelectedIndeces())
                    {
                        _DeviceManager.SetLedOne((byte)i, color);
                    }
                }
            }
        }

        #endregion

        #region Timeouts

        private void tbEffectSpeed_ValueChanged(object sender, EventArgs e)
        {
            lblEffectSpeedDisp.Text = string.Format("{0} ms", tbEffectSpeed.Value);
            SendLedConfig();
        }

        private void tbStrobeSpeed_ValueChanged(object sender, EventArgs e)
        {
            lblStrobeSpeedDisp.Text = string.Format("{0} ms", tbStrobeSpeed.Value);
            SendLedConfig();
        }

        #endregion

        private void DeviceManager_LedConfigReceived(object sender, LedConfigReceivedEventArgs e)
        {
            Invoke(() =>
            {
                // Mode
                cbLedMode.SelectedIndex = e.LedConfig.Mode;
                cbLedMode_SelectedIndexChanged(sender, e); // Enable or disable buttons based on mode

                // Effect speeds
                tbEffectSpeed.Value = Clamp(tbEffectSpeed, (int)e.LedConfig.Timeout1);
                tbStrobeSpeed.Value = Clamp(tbStrobeSpeed, e.LedConfig.Timeout2);

                // Colors
                colorBindingSource.Clear();
                foreach (var c in e.LedConfig.Colors)
                {
                    colorBindingSource.Add(c);
                }
            });
        }

        private void btnSaveLedConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Properties.Resources.ConfirmSaveLed, Properties.Resources.ConfirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _DeviceManager.CommitLedConfig();
            }
        }

        private void SendLedConfig()
        {
            if (cbLedMode.SelectedIndex < 0) return;
            var ledConfig = new LedConfig((byte)cbLedMode.SelectedIndex, colorBindingSource.Cast<Color>().ToArray(), (uint)tbEffectSpeed.Value, (ushort)tbStrobeSpeed.Value);
            _DeviceManager.SetLedConfig(ledConfig);
        }

        #endregion

        #region Helper methods

        private void Invoke(Action action)
        {
            try
            {
                Invoke((Delegate)action);
            }
            catch (ObjectDisposedException)
            {
                // Ignore: the DeviceManager background thread is disposed of asynchronously, so events may still be raised even after the form is disposed
            }
        }

        private int Clamp(TrackBar tb, int value)
        {
            if (value < tb.Minimum) value = tb.Minimum;
            if (value > tb.Maximum) value = tb.Maximum;
            return value;
        }

        private int CustomColorToBGR(CustomColor cc)
        {
            return (cc.B << 16) + (cc.G << 8) + cc.R;
        }

        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ledLayoutControl.DataSource = null;
            if (_DeviceManager != null) _DeviceManager.Dispose();
        }
    }
}
