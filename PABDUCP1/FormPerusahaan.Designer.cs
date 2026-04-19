namespace PABDUCP1
{
    partial class FormPerusahaan
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLowongan = new System.Windows.Forms.Button();
            this.btnAcc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD PERUSAHAAN";
            // 
            // btnLowongan
            // 
            this.btnLowongan.BackColor = System.Drawing.SystemColors.Info;
            this.btnLowongan.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowongan.Location = new System.Drawing.Point(306, 147);
            this.btnLowongan.Name = "btnLowongan";
            this.btnLowongan.Size = new System.Drawing.Size(173, 38);
            this.btnLowongan.TabIndex = 1;
            this.btnLowongan.Text = "Kelola Lowongan";
            this.btnLowongan.UseVisualStyleBackColor = false;
            this.btnLowongan.Click += new System.EventHandler(this.btnLowongan_Click);
            // 
            // btnAcc
            // 
            this.btnAcc.BackColor = System.Drawing.SystemColors.Info;
            this.btnAcc.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcc.Location = new System.Drawing.Point(306, 213);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(173, 38);
            this.btnAcc.TabIndex = 2;
            this.btnAcc.Text = "ACC Lamaran";
            this.btnAcc.UseVisualStyleBackColor = false;
            this.btnAcc.Click += new System.EventHandler(this.btnLamaran_Click);
            // 
            // FormPerusahaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAcc);
            this.Controls.Add(this.btnLowongan);
            this.Controls.Add(this.label1);
            this.Name = "FormPerusahaan";
            this.Text = "FormPerusahaan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLowongan;
        private System.Windows.Forms.Button btnAcc;
    }
}