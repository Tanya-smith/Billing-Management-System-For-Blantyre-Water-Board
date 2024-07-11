
namespace IBMSystem
{
    partial class EmpUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpUC));
            this.siticonePanel5 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.EmpID_lbl = new System.Windows.Forms.Label();
            this.EmpName_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // siticonePanel5
            // 
            this.siticonePanel5.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("siticonePanel5.BackgroundImage")));
            this.siticonePanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.siticonePanel5.BorderColor = System.Drawing.Color.Gray;
            this.siticonePanel5.BorderRadius = 20;
            this.siticonePanel5.BorderThickness = 2;
            this.siticonePanel5.Location = new System.Drawing.Point(8, 5);
            this.siticonePanel5.Name = "siticonePanel5";
            this.siticonePanel5.ShadowDecoration.Parent = this.siticonePanel5;
            this.siticonePanel5.Size = new System.Drawing.Size(45, 45);
            this.siticonePanel5.TabIndex = 16;
            // 
            // EmpID_lbl
            // 
            this.EmpID_lbl.AutoSize = true;
            this.EmpID_lbl.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmpID_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.EmpID_lbl.Location = new System.Drawing.Point(59, 5);
            this.EmpID_lbl.Name = "EmpID_lbl";
            this.EmpID_lbl.Size = new System.Drawing.Size(60, 20);
            this.EmpID_lbl.TabIndex = 17;
            this.EmpID_lbl.Text = "EMP001";
            // 
            // EmpName_lbl
            // 
            this.EmpName_lbl.AutoSize = true;
            this.EmpName_lbl.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmpName_lbl.ForeColor = System.Drawing.Color.DimGray;
            this.EmpName_lbl.Location = new System.Drawing.Point(59, 30);
            this.EmpName_lbl.Name = "EmpName_lbl";
            this.EmpName_lbl.Size = new System.Drawing.Size(105, 20);
            this.EmpName_lbl.TabIndex = 18;
            this.EmpName_lbl.Text = "Martin Micheal";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(186, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 35);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // EmpUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EmpName_lbl);
            this.Controls.Add(this.EmpID_lbl);
            this.Controls.Add(this.siticonePanel5);
            this.Name = "EmpUC";
            this.Size = new System.Drawing.Size(232, 55);
            this.Click += new System.EventHandler(this.EmpUC_Click);
            this.MouseLeave += new System.EventHandler(this.EmpUC_MouseLeave);
            this.MouseHover += new System.EventHandler(this.EmpUC_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel5;
        private System.Windows.Forms.Label EmpID_lbl;
        private System.Windows.Forms.Label EmpName_lbl;
        private System.Windows.Forms.Button button1;
    }
}
