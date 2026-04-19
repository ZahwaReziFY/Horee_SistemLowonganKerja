namespace PABDUCP1
{
    partial class FormLamar
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
            this.txtIDLowongan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIDLowongan
            // 
            this.txtIDLowongan.Location = new System.Drawing.Point(271, 230);
            this.txtIDLowongan.Name = "txtIDLowongan";
            this.txtIDLowongan.Size = new System.Drawing.Size(271, 22);
            this.txtIDLowongan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "LAMAR PEKERJAAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Thistle;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID Lowongan";
            // 
            // btnLamar
            // 
            this.btnLamar.BackColor = System.Drawing.SystemColors.Info;
            this.btnLamar.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamar.Location = new System.Drawing.Point(319, 281);
            this.btnLamar.Name = "btnLamar";
            this.btnLamar.Size = new System.Drawing.Size(75, 40);
            this.btnLamar.TabIndex = 3;
            this.btnLamar.Text = "DONE";
            this.btnLamar.UseVisualStyleBackColor = false;
            this.btnLamar.Click += new System.EventHandler(this.btnLamar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Thistle;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 46);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID User";
            // 
            // txtIDUser
            // 
            this.txtIDUser.Location = new System.Drawing.Point(271, 157);
            this.txtIDUser.Name = "txtIDUser";
            this.txtIDUser.Size = new System.Drawing.Size(271, 22);
            this.txtIDUser.TabIndex = 5;
            // 
            // FormLamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtIDUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLamar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDLowongan);
            this.Name = "FormLamar";
            this.Text = "FormLamar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDLowongan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLamar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDUser;
    }
}