
namespace IBMSystem
{
    partial class ViewImageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewImageFrm));
            this.accFrmTopHeaderPNL = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.Back_CMD = new System.Windows.Forms.Button();
            this.Heading_lbl = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.ImageBox_PB = new System.Windows.Forms.PictureBox();
            this.ConfirmPayment_BTN = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.TransactionCode_TXT = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.accFrmTopHeaderPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // accFrmTopHeaderPNL
            // 
            this.accFrmTopHeaderPNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(242)))));
            this.accFrmTopHeaderPNL.Controls.Add(this.Back_CMD);
            this.accFrmTopHeaderPNL.Controls.Add(this.Heading_lbl);
            this.accFrmTopHeaderPNL.Dock = System.Windows.Forms.DockStyle.Top;
            this.accFrmTopHeaderPNL.Location = new System.Drawing.Point(0, 0);
            this.accFrmTopHeaderPNL.Name = "accFrmTopHeaderPNL";
            this.accFrmTopHeaderPNL.ShadowDecoration.Parent = this.accFrmTopHeaderPNL;
            this.accFrmTopHeaderPNL.Size = new System.Drawing.Size(610, 35);
            this.accFrmTopHeaderPNL.TabIndex = 1;
            // 
            // Back_CMD
            // 
            this.Back_CMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.Back_CMD.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Back_CMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.Back_CMD.FlatAppearance.BorderSize = 0;
            this.Back_CMD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(77)))), ((int)(((byte)(119)))));
            this.Back_CMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_CMD.Image = ((System.Drawing.Image)(resources.GetObject("Back_CMD.Image")));
            this.Back_CMD.Location = new System.Drawing.Point(0, 0);
            this.Back_CMD.Name = "Back_CMD";
            this.Back_CMD.Size = new System.Drawing.Size(46, 35);
            this.Back_CMD.TabIndex = 10;
            this.Back_CMD.UseVisualStyleBackColor = false;
            // 
            // Heading_lbl
            // 
            this.Heading_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Heading_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading_lbl.ForeColor = System.Drawing.Color.White;
            this.Heading_lbl.Location = new System.Drawing.Point(58, 5);
            this.Heading_lbl.Name = "Heading_lbl";
            this.Heading_lbl.Size = new System.Drawing.Size(142, 25);
            this.Heading_lbl.TabIndex = 9;
            this.Heading_lbl.Text = "Proof Of Payment";
            // 
            // ImageBox_PB
            // 
            this.ImageBox_PB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImageBox_PB.Location = new System.Drawing.Point(0, 35);
            this.ImageBox_PB.Name = "ImageBox_PB";
            this.ImageBox_PB.Size = new System.Drawing.Size(610, 502);
            this.ImageBox_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBox_PB.TabIndex = 2;
            this.ImageBox_PB.TabStop = false;
            // 
            // ConfirmPayment_BTN
            // 
            this.ConfirmPayment_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmPayment_BTN.Animated = true;
            this.ConfirmPayment_BTN.BorderRadius = 5;
            this.ConfirmPayment_BTN.CheckedState.Parent = this.ConfirmPayment_BTN;
            this.ConfirmPayment_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmPayment_BTN.CustomImages.Parent = this.ConfirmPayment_BTN;
            this.ConfirmPayment_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmPayment_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ConfirmPayment_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConfirmPayment_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConfirmPayment_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ConfirmPayment_BTN.DisabledState.Parent = this.ConfirmPayment_BTN;
            this.ConfirmPayment_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.ConfirmPayment_BTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.ConfirmPayment_BTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPayment_BTN.ForeColor = System.Drawing.Color.White;
            this.ConfirmPayment_BTN.HoverState.Parent = this.ConfirmPayment_BTN;
            this.ConfirmPayment_BTN.Location = new System.Drawing.Point(247, 557);
            this.ConfirmPayment_BTN.Name = "ConfirmPayment_BTN";
            this.ConfirmPayment_BTN.ShadowDecoration.Parent = this.ConfirmPayment_BTN;
            this.ConfirmPayment_BTN.Size = new System.Drawing.Size(362, 40);
            this.ConfirmPayment_BTN.TabIndex = 26;
            this.ConfirmPayment_BTN.Text = "CONFIRM PAYMENT";
            this.ConfirmPayment_BTN.Click += new System.EventHandler(this.ConfirmPayment_BTN_Click);
            // 
            // TransactionCode_TXT
            // 
            this.TransactionCode_TXT.BorderColor = System.Drawing.Color.Gray;
            this.TransactionCode_TXT.BorderRadius = 4;
            this.TransactionCode_TXT.BorderThickness = 2;
            this.TransactionCode_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransactionCode_TXT.DefaultText = "";
            this.TransactionCode_TXT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TransactionCode_TXT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TransactionCode_TXT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TransactionCode_TXT.DisabledState.Parent = this.TransactionCode_TXT;
            this.TransactionCode_TXT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TransactionCode_TXT.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.TransactionCode_TXT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(242)))));
            this.TransactionCode_TXT.FocusedState.Parent = this.TransactionCode_TXT;
            this.TransactionCode_TXT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TransactionCode_TXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TransactionCode_TXT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.TransactionCode_TXT.HoverState.Parent = this.TransactionCode_TXT;
            this.TransactionCode_TXT.IconLeft = ((System.Drawing.Image)(resources.GetObject("TransactionCode_TXT.IconLeft")));
            this.TransactionCode_TXT.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.TransactionCode_TXT.IconRightOffset = new System.Drawing.Point(5, 0);
            this.TransactionCode_TXT.Location = new System.Drawing.Point(12, 558);
            this.TransactionCode_TXT.Name = "TransactionCode_TXT";
            this.TransactionCode_TXT.PasswordChar = '\0';
            this.TransactionCode_TXT.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TransactionCode_TXT.PlaceholderText = "Enter Transaction code";
            this.TransactionCode_TXT.SelectedText = "";
            this.TransactionCode_TXT.ShadowDecoration.Parent = this.TransactionCode_TXT;
            this.TransactionCode_TXT.Size = new System.Drawing.Size(229, 36);
            this.TransactionCode_TXT.TabIndex = 28;
            this.TransactionCode_TXT.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // ViewImageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 610);
            this.Controls.Add(this.TransactionCode_TXT);
            this.Controls.Add(this.ConfirmPayment_BTN);
            this.Controls.Add(this.ImageBox_PB);
            this.Controls.Add(this.accFrmTopHeaderPNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewImageFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewImageFrm";
            this.Load += new System.EventHandler(this.ViewImageFrm_Load);
            this.accFrmTopHeaderPNL.ResumeLayout(false);
            this.accFrmTopHeaderPNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox_PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticonePanel accFrmTopHeaderPNL;
        private System.Windows.Forms.Button Back_CMD;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel Heading_lbl;
        private System.Windows.Forms.PictureBox ImageBox_PB;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton ConfirmPayment_BTN;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox TransactionCode_TXT;
    }
}