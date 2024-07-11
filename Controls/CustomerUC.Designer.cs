
namespace IBMSystem
{
    partial class CustomerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerUC));
            this.AccountNo_LBL = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.AccCustFirstname_LBL = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.siticoneCirclePictureBox1 = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AccCustSurname_LBL = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.siticoneCirclePictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountNo_LBL
            // 
            this.AccountNo_LBL.BackColor = System.Drawing.Color.Transparent;
            this.AccountNo_LBL.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNo_LBL.ForeColor = System.Drawing.Color.DimGray;
            this.AccountNo_LBL.Location = new System.Drawing.Point(38, 86);
            this.AccountNo_LBL.Name = "AccountNo_LBL";
            this.AccountNo_LBL.Size = new System.Drawing.Size(73, 22);
            this.AccountNo_LBL.TabIndex = 9;
            this.AccountNo_LBL.Text = "001938489";
            // 
            // AccCustFirstname_LBL
            // 
            this.AccCustFirstname_LBL.BackColor = System.Drawing.Color.Transparent;
            this.AccCustFirstname_LBL.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccCustFirstname_LBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(84)))));
            this.AccCustFirstname_LBL.Location = new System.Drawing.Point(38, 106);
            this.AccCustFirstname_LBL.Name = "AccCustFirstname_LBL";
            this.AccCustFirstname_LBL.Size = new System.Drawing.Size(29, 19);
            this.AccCustFirstname_LBL.TabIndex = 10;
            this.AccCustFirstname_LBL.Text = "Elvis";
            // 
            // siticoneCirclePictureBox1
            // 
            this.siticoneCirclePictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.siticoneCirclePictureBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(242)))));
            this.siticoneCirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("siticoneCirclePictureBox1.Image")));
            this.siticoneCirclePictureBox1.ImageRotate = 0F;
            this.siticoneCirclePictureBox1.Location = new System.Drawing.Point(3, 3);
            this.siticoneCirclePictureBox1.Name = "siticoneCirclePictureBox1";
            this.siticoneCirclePictureBox1.ShadowDecoration.BorderRadius = 50;
            this.siticoneCirclePictureBox1.ShadowDecoration.Color = System.Drawing.Color.Maroon;
            this.siticoneCirclePictureBox1.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.siticoneCirclePictureBox1.ShadowDecoration.Parent = this.siticoneCirclePictureBox1;
            this.siticoneCirclePictureBox1.Size = new System.Drawing.Size(64, 64);
            this.siticoneCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.siticoneCirclePictureBox1.TabIndex = 11;
            this.siticoneCirclePictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.siticoneCirclePictureBox1);
            this.panel1.Location = new System.Drawing.Point(38, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 70);
            this.panel1.TabIndex = 12;
            // 
            // AccCustSurname_LBL
            // 
            this.AccCustSurname_LBL.BackColor = System.Drawing.Color.Transparent;
            this.AccCustSurname_LBL.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccCustSurname_LBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(84)))));
            this.AccCustSurname_LBL.Location = new System.Drawing.Point(38, 126);
            this.AccCustSurname_LBL.Name = "AccCustSurname_LBL";
            this.AccCustSurname_LBL.Size = new System.Drawing.Size(53, 19);
            this.AccCustSurname_LBL.TabIndex = 13;
            this.AccCustSurname_LBL.Text = "Namuru";
            // 
            // CustomerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.AccCustSurname_LBL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AccCustFirstname_LBL);
            this.Controls.Add(this.AccountNo_LBL);
            this.Name = "CustomerUC";
            this.Click += new System.EventHandler(this.CustomerUC_Click);
            this.MouseLeave += new System.EventHandler(this.CustomerUC_MouseLeave);
            this.MouseHover += new System.EventHandler(this.CustomerUC_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.siticoneCirclePictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel AccountNo_LBL;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel AccCustFirstname_LBL;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox siticoneCirclePictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel AccCustSurname_LBL;
    }
}
