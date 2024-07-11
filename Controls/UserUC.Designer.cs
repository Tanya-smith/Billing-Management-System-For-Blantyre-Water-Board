
namespace IBMSystem
{
    partial class UserUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserUC));
            this.Username_lbl = new System.Windows.Forms.Label();
            this.UserID_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.siticonePanel5 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.SuspendLayout();
            // 
            // Username_lbl
            // 
            this.Username_lbl.AutoSize = true;
            this.Username_lbl.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.Username_lbl.Location = new System.Drawing.Point(61, 30);
            this.Username_lbl.Name = "Username_lbl";
            this.Username_lbl.Size = new System.Drawing.Size(57, 20);
            this.Username_lbl.TabIndex = 22;
            this.Username_lbl.Text = "JanDoe";
            // 
            // UserID_lbl
            // 
            this.UserID_lbl.AutoSize = true;
            this.UserID_lbl.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.UserID_lbl.Location = new System.Drawing.Point(61, 5);
            this.UserID_lbl.Name = "UserID_lbl";
            this.UserID_lbl.Size = new System.Drawing.Size(59, 20);
            this.UserID_lbl.TabIndex = 21;
            this.UserID_lbl.Text = "USD001";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(188, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 35);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // siticonePanel5
            // 
            this.siticonePanel5.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("siticonePanel5.BackgroundImage")));
            this.siticonePanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.siticonePanel5.BorderColor = System.Drawing.Color.Gray;
            this.siticonePanel5.BorderRadius = 5;
            this.siticonePanel5.BorderThickness = 2;
            this.siticonePanel5.Location = new System.Drawing.Point(10, 5);
            this.siticonePanel5.Name = "siticonePanel5";
            this.siticonePanel5.ShadowDecoration.Parent = this.siticonePanel5;
            this.siticonePanel5.Size = new System.Drawing.Size(45, 45);
            this.siticonePanel5.TabIndex = 20;
            // 
            // UserUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Username_lbl);
            this.Controls.Add(this.UserID_lbl);
            this.Controls.Add(this.siticonePanel5);
            this.Name = "UserUC";
            this.Size = new System.Drawing.Size(232, 55);
            this.Click += new System.EventHandler(this.UserUC_Click);
            this.MouseLeave += new System.EventHandler(this.UserUC_MouseLeave);
            this.MouseHover += new System.EventHandler(this.UserUC_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Username_lbl;
        private System.Windows.Forms.Label UserID_lbl;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel5;
    }
}
