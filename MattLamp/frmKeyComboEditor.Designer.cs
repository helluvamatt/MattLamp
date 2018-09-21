namespace MattLamp
{
    partial class frmKeyComboEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbKeyCode = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkModLShift = new System.Windows.Forms.CheckBox();
            this.chkModLCtrl = new System.Windows.Forms.CheckBox();
            this.chkModLAlt = new System.Windows.Forms.CheckBox();
            this.chkModLGUI = new System.Windows.Forms.CheckBox();
            this.chkModRGUI = new System.Windows.Forms.CheckBox();
            this.chkModRAlt = new System.Windows.Forms.CheckBox();
            this.chkModRCtrl = new System.Windows.Forms.CheckBox();
            this.chkModRShift = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbKeyCode
            // 
            this.cbKeyCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKeyCode.DisplayMember = "Name";
            this.cbKeyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyCode.FormattingEnabled = true;
            this.cbKeyCode.Location = new System.Drawing.Point(245, 22);
            this.cbKeyCode.Name = "cbKeyCode";
            this.cbKeyCode.Size = new System.Drawing.Size(74, 21);
            this.cbKeyCode.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(163, 57);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkModLShift
            // 
            this.chkModLShift.AutoSize = true;
            this.chkModLShift.Location = new System.Drawing.Point(66, 12);
            this.chkModLShift.Name = "chkModLShift";
            this.chkModLShift.Size = new System.Drawing.Size(56, 17);
            this.chkModLShift.TabIndex = 3;
            this.chkModLShift.Text = "L Shift";
            this.chkModLShift.UseVisualStyleBackColor = true;
            // 
            // chkModLCtrl
            // 
            this.chkModLCtrl.AutoSize = true;
            this.chkModLCtrl.Location = new System.Drawing.Point(10, 12);
            this.chkModLCtrl.Name = "chkModLCtrl";
            this.chkModLCtrl.Size = new System.Drawing.Size(50, 17);
            this.chkModLCtrl.TabIndex = 4;
            this.chkModLCtrl.Text = "L Ctrl";
            this.chkModLCtrl.UseVisualStyleBackColor = true;
            // 
            // chkModLAlt
            // 
            this.chkModLAlt.AutoSize = true;
            this.chkModLAlt.Location = new System.Drawing.Point(130, 12);
            this.chkModLAlt.Name = "chkModLAlt";
            this.chkModLAlt.Size = new System.Drawing.Size(47, 17);
            this.chkModLAlt.TabIndex = 5;
            this.chkModLAlt.Text = "L Alt";
            this.chkModLAlt.UseVisualStyleBackColor = true;
            // 
            // chkModLGUI
            // 
            this.chkModLGUI.AutoSize = true;
            this.chkModLGUI.Location = new System.Drawing.Point(183, 12);
            this.chkModLGUI.Name = "chkModLGUI";
            this.chkModLGUI.Size = new System.Drawing.Size(54, 17);
            this.chkModLGUI.TabIndex = 6;
            this.chkModLGUI.Text = "L GUI";
            this.chkModLGUI.UseVisualStyleBackColor = true;
            // 
            // chkModRGUI
            // 
            this.chkModRGUI.AutoSize = true;
            this.chkModRGUI.Location = new System.Drawing.Point(183, 35);
            this.chkModRGUI.Name = "chkModRGUI";
            this.chkModRGUI.Size = new System.Drawing.Size(56, 17);
            this.chkModRGUI.TabIndex = 10;
            this.chkModRGUI.Text = "R GUI";
            this.chkModRGUI.UseVisualStyleBackColor = true;
            // 
            // chkModRAlt
            // 
            this.chkModRAlt.AutoSize = true;
            this.chkModRAlt.Location = new System.Drawing.Point(130, 35);
            this.chkModRAlt.Name = "chkModRAlt";
            this.chkModRAlt.Size = new System.Drawing.Size(49, 17);
            this.chkModRAlt.TabIndex = 9;
            this.chkModRAlt.Text = "R Alt";
            this.chkModRAlt.UseVisualStyleBackColor = true;
            // 
            // chkModRCtrl
            // 
            this.chkModRCtrl.AutoSize = true;
            this.chkModRCtrl.Location = new System.Drawing.Point(10, 35);
            this.chkModRCtrl.Name = "chkModRCtrl";
            this.chkModRCtrl.Size = new System.Drawing.Size(52, 17);
            this.chkModRCtrl.TabIndex = 8;
            this.chkModRCtrl.Text = "R Ctrl";
            this.chkModRCtrl.UseVisualStyleBackColor = true;
            // 
            // chkModRShift
            // 
            this.chkModRShift.AutoSize = true;
            this.chkModRShift.Location = new System.Drawing.Point(66, 35);
            this.chkModRShift.Name = "chkModRShift";
            this.chkModRShift.Size = new System.Drawing.Size(58, 17);
            this.chkModRShift.TabIndex = 7;
            this.chkModRShift.Text = "R Shift";
            this.chkModRShift.UseVisualStyleBackColor = true;
            // 
            // frmKeyComboEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 92);
            this.Controls.Add(this.chkModRGUI);
            this.Controls.Add(this.chkModRAlt);
            this.Controls.Add(this.chkModRCtrl);
            this.Controls.Add(this.chkModRShift);
            this.Controls.Add(this.chkModLGUI);
            this.Controls.Add(this.chkModLAlt);
            this.Controls.Add(this.chkModLCtrl);
            this.Controls.Add(this.chkModLShift);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbKeyCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKeyComboEditor";
            this.Text = "Configure key combination...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKeyCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkModLShift;
        private System.Windows.Forms.CheckBox chkModLCtrl;
        private System.Windows.Forms.CheckBox chkModLAlt;
        private System.Windows.Forms.CheckBox chkModLGUI;
        private System.Windows.Forms.CheckBox chkModRGUI;
        private System.Windows.Forms.CheckBox chkModRAlt;
        private System.Windows.Forms.CheckBox chkModRCtrl;
        private System.Windows.Forms.CheckBox chkModRShift;
    }
}