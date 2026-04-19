namespace PABDUCP1
{
    partial class FormRegisterUser
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
            this.Registrasi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtJalan = new System.Windows.Forms.TextBox();
            this.txtDesa = new System.Windows.Forms.TextBox();
            this.txtKabupaten = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Registrasi
            // 
            this.Registrasi.AutoSize = true;
            this.Registrasi.BackColor = System.Drawing.Color.LavenderBlush;
            this.Registrasi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Registrasi.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registrasi.ForeColor = System.Drawing.Color.SkyBlue;
            this.Registrasi.Location = new System.Drawing.Point(320, 11);
            this.Registrasi.Name = "Registrasi";
            this.Registrasi.Size = new System.Drawing.Size(132, 70);
            this.Registrasi.TabIndex = 0;
            this.Registrasi.Text = "Registrasi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label2.Location = new System.Drawing.Point(135, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(135, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label4.Location = new System.Drawing.Point(120, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 44);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label5.Location = new System.Drawing.Point(135, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 44);
            this.label5.TabIndex = 4;
            this.label5.Text = "Jalan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label6.Location = new System.Drawing.Point(136, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 44);
            this.label6.TabIndex = 5;
            this.label6.Text = "Desa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label7.Location = new System.Drawing.Point(120, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 44);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kabupaten";
            // 
            // txtNama
            // 
            this.txtNama.BackColor = System.Drawing.Color.Azure;
            this.txtNama.Location = new System.Drawing.Point(247, 97);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(278, 22);
            this.txtNama.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Azure;
            this.txtEmail.Location = new System.Drawing.Point(247, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 22);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Azure;
            this.txtPassword.Location = new System.Drawing.Point(248, 169);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(277, 22);
            this.txtPassword.TabIndex = 9;
            // 
            // txtJalan
            // 
            this.txtJalan.BackColor = System.Drawing.Color.Azure;
            this.txtJalan.Location = new System.Drawing.Point(248, 203);
            this.txtJalan.Name = "txtJalan";
            this.txtJalan.Size = new System.Drawing.Size(277, 22);
            this.txtJalan.TabIndex = 10;
            // 
            // txtDesa
            // 
            this.txtDesa.BackColor = System.Drawing.Color.Azure;
            this.txtDesa.Location = new System.Drawing.Point(247, 239);
            this.txtDesa.Name = "txtDesa";
            this.txtDesa.Size = new System.Drawing.Size(278, 22);
            this.txtDesa.TabIndex = 11;
            // 
            // txtKabupaten
            // 
            this.txtKabupaten.BackColor = System.Drawing.Color.Azure;
            this.txtKabupaten.Location = new System.Drawing.Point(247, 276);
            this.txtKabupaten.Name = "txtKabupaten";
            this.txtKabupaten.Size = new System.Drawing.Size(278, 22);
            this.txtKabupaten.TabIndex = 12;
            this.txtKabupaten.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Info;
            this.btnRegister.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(247, 346);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(103, 39);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Regist";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Info;
            this.btnLogin.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(426, 346);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(99, 39);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FormRegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtKabupaten);
            this.Controls.Add(this.txtDesa);
            this.Controls.Add(this.txtJalan);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Registrasi);
            this.Name = "FormRegisterUser";
            this.Text = "FormRegisterUser";
            this.Load += new System.EventHandler(this.FormRegisterUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Registrasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtJalan;
        private System.Windows.Forms.TextBox txtDesa;
        private System.Windows.Forms.TextBox txtKabupaten;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
    }
}