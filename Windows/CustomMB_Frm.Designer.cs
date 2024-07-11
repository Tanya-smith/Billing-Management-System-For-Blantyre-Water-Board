
namespace IBMSystem
{
    partial class CustomMB_Frm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMB_Frm));
            this.Header_PNL = new System.Windows.Forms.Panel();
            this.Close_CMD = new System.Windows.Forms.Button();
            this.Title_lbl = new System.Windows.Forms.Label();
            this.Message_lbl = new System.Windows.Forms.Label();
            this.Yes_BTN = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.OK_BTN = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.No_BTN = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.Cancel_BTN = new Siticone.Desktop.UI.WinForms.SiticoneGradientButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FormDrag_BDC = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Icon_PB = new System.Windows.Forms.PictureBox();
            this.Header_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Header_PNL
            // 
            this.Header_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(143)))));
            this.Header_PNL.Controls.Add(this.Close_CMD);
            this.Header_PNL.Controls.Add(this.Title_lbl);
            this.Header_PNL.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header_PNL.Location = new System.Drawing.Point(0, 0);
            this.Header_PNL.Name = "Header_PNL";
            this.Header_PNL.Size = new System.Drawing.Size(340, 31);
            this.Header_PNL.TabIndex = 0;
            // 
            // Close_CMD
            // 
            this.Close_CMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_CMD.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close_CMD.FlatAppearance.BorderSize = 0;
            this.Close_CMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_CMD.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_CMD.ForeColor = System.Drawing.Color.Red;
            this.Close_CMD.Location = new System.Drawing.Point(304, 0);
            this.Close_CMD.Name = "Close_CMD";
            this.Close_CMD.Size = new System.Drawing.Size(36, 31);
            this.Close_CMD.TabIndex = 2;
            this.Close_CMD.Text = "X";
            this.Close_CMD.UseVisualStyleBackColor = true;
            this.Close_CMD.Click += new System.EventHandler(this.Close_CMD_Click);
            // 
            // Title_lbl
            // 
            this.Title_lbl.AutoSize = true;
            this.Title_lbl.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_lbl.ForeColor = System.Drawing.Color.White;
            this.Title_lbl.Location = new System.Drawing.Point(5, 3);
            this.Title_lbl.Name = "Title_lbl";
            this.Title_lbl.Size = new System.Drawing.Size(124, 25);
            this.Title_lbl.TabIndex = 3;
            this.Title_lbl.Text = "Message Title";
            // 
            // Message_lbl
            // 
            this.Message_lbl.AutoSize = true;
            this.Message_lbl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.Message_lbl.Location = new System.Drawing.Point(76, 110);
            this.Message_lbl.Name = "Message_lbl";
            this.Message_lbl.Size = new System.Drawing.Size(79, 18);
            this.Message_lbl.TabIndex = 5;
            this.Message_lbl.Text = "Message";
            this.Message_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Yes_BTN
            // 
            this.Yes_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yes_BTN.Animated = true;
            this.Yes_BTN.BorderRadius = 5;
            this.Yes_BTN.CheckedState.Parent = this.Yes_BTN;
            this.Yes_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Yes_BTN.CustomImages.Parent = this.Yes_BTN;
            this.Yes_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Yes_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Yes_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Yes_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Yes_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Yes_BTN.DisabledState.Parent = this.Yes_BTN;
            this.Yes_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(143)))));
            this.Yes_BTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.Yes_BTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yes_BTN.ForeColor = System.Drawing.Color.White;
            this.Yes_BTN.HoverState.Parent = this.Yes_BTN;
            this.Yes_BTN.Location = new System.Drawing.Point(128, 196);
            this.Yes_BTN.Name = "Yes_BTN";
            this.Yes_BTN.ShadowDecoration.Parent = this.Yes_BTN;
            this.Yes_BTN.Size = new System.Drawing.Size(62, 32);
            this.Yes_BTN.TabIndex = 55;
            this.Yes_BTN.Text = "Yes";
            this.Yes_BTN.Click += new System.EventHandler(this.Yes_BTN_Click);
            // 
            // OK_BTN
            // 
            this.OK_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_BTN.Animated = true;
            this.OK_BTN.BorderRadius = 5;
            this.OK_BTN.CheckedState.Parent = this.OK_BTN;
            this.OK_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK_BTN.CustomImages.Parent = this.OK_BTN;
            this.OK_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OK_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OK_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OK_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OK_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OK_BTN.DisabledState.Parent = this.OK_BTN;
            this.OK_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(143)))));
            this.OK_BTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.OK_BTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK_BTN.ForeColor = System.Drawing.Color.White;
            this.OK_BTN.HoverState.Parent = this.OK_BTN;
            this.OK_BTN.Location = new System.Drawing.Point(266, 196);
            this.OK_BTN.Name = "OK_BTN";
            this.OK_BTN.ShadowDecoration.Parent = this.OK_BTN;
            this.OK_BTN.Size = new System.Drawing.Size(62, 32);
            this.OK_BTN.TabIndex = 56;
            this.OK_BTN.Text = "Ok";
            this.OK_BTN.Click += new System.EventHandler(this.OK_BTN_Click);
            // 
            // No_BTN
            // 
            this.No_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.No_BTN.Animated = true;
            this.No_BTN.BorderRadius = 5;
            this.No_BTN.CheckedState.Parent = this.No_BTN;
            this.No_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.No_BTN.CustomImages.Parent = this.No_BTN;
            this.No_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.No_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.No_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.No_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.No_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.No_BTN.DisabledState.Parent = this.No_BTN;
            this.No_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(143)))));
            this.No_BTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.No_BTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No_BTN.ForeColor = System.Drawing.Color.White;
            this.No_BTN.HoverState.Parent = this.No_BTN;
            this.No_BTN.Location = new System.Drawing.Point(196, 196);
            this.No_BTN.Name = "No_BTN";
            this.No_BTN.ShadowDecoration.Parent = this.No_BTN;
            this.No_BTN.Size = new System.Drawing.Size(62, 32);
            this.No_BTN.TabIndex = 57;
            this.No_BTN.Text = "No";
            this.No_BTN.Click += new System.EventHandler(this.No_BTN_Click);
            // 
            // Cancel_BTN
            // 
            this.Cancel_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_BTN.Animated = true;
            this.Cancel_BTN.BorderRadius = 5;
            this.Cancel_BTN.CheckedState.Parent = this.Cancel_BTN;
            this.Cancel_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_BTN.CustomImages.Parent = this.Cancel_BTN;
            this.Cancel_BTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_BTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Cancel_BTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cancel_BTN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Cancel_BTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Cancel_BTN.DisabledState.Parent = this.Cancel_BTN;
            this.Cancel_BTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(70)))), ((int)(((byte)(143)))));
            this.Cancel_BTN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(147)))), ((int)(((byte)(201)))));
            this.Cancel_BTN.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_BTN.ForeColor = System.Drawing.Color.White;
            this.Cancel_BTN.HoverState.Parent = this.Cancel_BTN;
            this.Cancel_BTN.Location = new System.Drawing.Point(266, 196);
            this.Cancel_BTN.Name = "Cancel_BTN";
            this.Cancel_BTN.ShadowDecoration.Parent = this.Cancel_BTN;
            this.Cancel_BTN.Size = new System.Drawing.Size(62, 32);
            this.Cancel_BTN.TabIndex = 58;
            this.Cancel_BTN.Text = "Cancel";
            this.Cancel_BTN.Click += new System.EventHandler(this.Cancel_BTN_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(242)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 5);
            this.panel2.TabIndex = 59;
            // 
            // FormDrag_BDC
            // 
            this.FormDrag_BDC.Fixed = true;
            this.FormDrag_BDC.Horizontal = true;
            this.FormDrag_BDC.TargetControl = this.Header_PNL;
            this.FormDrag_BDC.Vertical = true;
            // 
            // Icon_PB
            // 
            this.Icon_PB.Image = ((System.Drawing.Image)(resources.GetObject("Icon_PB.Image")));
            this.Icon_PB.Location = new System.Drawing.Point(10, 89);
            this.Icon_PB.Name = "Icon_PB";
            this.Icon_PB.Size = new System.Drawing.Size(60, 60);
            this.Icon_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon_PB.TabIndex = 60;
            this.Icon_PB.TabStop = false;
            // 
            // CustomMB_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 239);
            this.Controls.Add(this.Icon_PB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Cancel_BTN);
            this.Controls.Add(this.No_BTN);
            this.Controls.Add(this.OK_BTN);
            this.Controls.Add(this.Yes_BTN);
            this.Controls.Add(this.Message_lbl);
            this.Controls.Add(this.Header_PNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomMB_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMB_Frm";
            this.Header_PNL.ResumeLayout(false);
            this.Header_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Header_PNL;
        private System.Windows.Forms.Button Close_CMD;
        private System.Windows.Forms.Label Title_lbl;
        private System.Windows.Forms.Label Message_lbl;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton Yes_BTN;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton OK_BTN;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton No_BTN;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientButton Cancel_BTN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Icon_PB;
        private Bunifu.Framework.UI.BunifuDragControl FormDrag_BDC;
    }
}