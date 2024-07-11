
namespace IBMSystem
{
    partial class PaymentUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentUC));
            this.ID_Pay_lbl = new System.Windows.Forms.Label();
            this.siticonePanel5 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.button1 = new System.Windows.Forms.Button();
            this.PayDate_DTP = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.SuspendLayout();
            // 
            // ID_Pay_lbl
            // 
            this.ID_Pay_lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Pay_lbl.ForeColor = System.Drawing.Color.White;
            this.ID_Pay_lbl.Location = new System.Drawing.Point(61, 5);
            this.ID_Pay_lbl.Name = "ID_Pay_lbl";
            this.ID_Pay_lbl.Size = new System.Drawing.Size(102, 20);
            this.ID_Pay_lbl.TabIndex = 21;
            this.ID_Pay_lbl.Text = "ID";
            // 
            // siticonePanel5
            // 
            this.siticonePanel5.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("siticonePanel5.BackgroundImage")));
            this.siticonePanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.siticonePanel5.BorderColor = System.Drawing.Color.White;
            this.siticonePanel5.BorderRadius = 20;
            this.siticonePanel5.Location = new System.Drawing.Point(6, 8);
            this.siticonePanel5.Name = "siticonePanel5";
            this.siticonePanel5.ShadowDecoration.Parent = this.siticonePanel5;
            this.siticonePanel5.Size = new System.Drawing.Size(45, 48);
            this.siticonePanel5.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(204, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 35);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // PayDate_DTP
            // 
            this.PayDate_DTP.BackColor = System.Drawing.Color.Transparent;
            this.PayDate_DTP.BorderColor = System.Drawing.Color.Gray;
            this.PayDate_DTP.BorderRadius = 4;
            this.PayDate_DTP.BorderThickness = 2;
            this.PayDate_DTP.CheckedState.Parent = this.PayDate_DTP;
            this.PayDate_DTP.CustomFormat = "yyyy-MM-dd";
            this.PayDate_DTP.Enabled = false;
            this.PayDate_DTP.FillColor = System.Drawing.Color.Gray;
            this.PayDate_DTP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayDate_DTP.ForeColor = System.Drawing.Color.White;
            this.PayDate_DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PayDate_DTP.HoverState.Parent = this.PayDate_DTP;
            this.PayDate_DTP.Location = new System.Drawing.Point(57, 29);
            this.PayDate_DTP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.PayDate_DTP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.PayDate_DTP.Name = "PayDate_DTP";
            this.PayDate_DTP.ShadowDecoration.Parent = this.PayDate_DTP;
            this.PayDate_DTP.Size = new System.Drawing.Size(145, 27);
            this.PayDate_DTP.TabIndex = 29;
            this.PayDate_DTP.Value = new System.DateTime(2022, 1, 4, 11, 33, 11, 949);
            // 
            // PaymentUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.PayDate_DTP);
            this.Controls.Add(this.siticonePanel5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ID_Pay_lbl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PaymentUC";
            this.Size = new System.Drawing.Size(242, 66);
            this.Click += new System.EventHandler(this.PaymentUC_Click);
            this.MouseLeave += new System.EventHandler(this.PaymentUC_MouseLeave);
            this.MouseHover += new System.EventHandler(this.PaymentUC_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ID_Pay_lbl;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel5;
        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker PayDate_DTP;
    }
}
