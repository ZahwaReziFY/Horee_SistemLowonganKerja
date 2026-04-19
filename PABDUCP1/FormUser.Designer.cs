namespace PABDUCP1
{
    partial class FormUser
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
            this.btnLihat = new System.Windows.Forms.Button();
            this.btnLamar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD USER";
            // 
            // btnLihat
            // 
            this.btnLihat.BackColor = System.Drawing.SystemColors.Info;
            this.btnLihat.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLihat.Location = new System.Drawing.Point(302, 155);
            this.btnLihat.Name = "btnLihat";
            this.btnLihat.Size = new System.Drawing.Size(185, 37);
            this.btnLihat.TabIndex = 1;
            this.btnLihat.Text = "Lihat Lowongan";
            this.btnLihat.UseVisualStyleBackColor = false;
            this.btnLihat.Click += new System.EventHandler(this.btnLihat_Click);
            // 
            // btnLamar
            // 
            this.btnLamar.BackColor = System.Drawing.SystemColors.Info;
            this.btnLamar.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamar.Location = new System.Drawing.Point(302, 225);
            this.btnLamar.Name = "btnLamar";
            this.btnLamar.Size = new System.Drawing.Size(185, 38);
            this.btnLamar.TabIndex = 2;
            this.btnLamar.Text = "Lamar Pekerjaan";
            this.btnLamar.UseVisualStyleBackColor = false;
            this.btnLamar.Click += new System.EventHandler(this.btnLamar_Click);
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLamar);
            this.Controls.Add(this.btnLihat);
            this.Controls.Add(this.label1);
            this.Name = "FormUser";
            this.Text = "FormUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLihat;
        private System.Windows.Forms.Button btnLamar;
    }
}