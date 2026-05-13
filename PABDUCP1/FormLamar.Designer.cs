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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLamar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.txtPosisi = new System.Windows.Forms.TextBox();
            this.txtPerusahaan = new System.Windows.Forms.TextBox();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(271, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "LAMAR PEKERJAAN";
            // 
            // btnLamar
            // 
            this.btnLamar.BackColor = System.Drawing.SystemColors.Info;
            this.btnLamar.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamar.Location = new System.Drawing.Point(343, 380);
            this.btnLamar.Name = "btnLamar";
            this.btnLamar.Size = new System.Drawing.Size(121, 40);
            this.btnLamar.TabIndex = 3;
            this.btnLamar.Text = "LAMAR!!!";
            this.btnLamar.UseVisualStyleBackColor = false;
            this.btnLamar.Click += new System.EventHandler(this.btnLamar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(102, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(619, 150);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(205, 342);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.ReadOnly = true;
            this.txtLokasi.Size = new System.Drawing.Size(229, 22);
            this.txtLokasi.TabIndex = 9;
            // 
            // txtPosisi
            // 
            this.txtPosisi.Location = new System.Drawing.Point(205, 265);
            this.txtPosisi.Name = "txtPosisi";
            this.txtPosisi.ReadOnly = true;
            this.txtPosisi.Size = new System.Drawing.Size(229, 22);
            this.txtPosisi.TabIndex = 10;
            // 
            // txtPerusahaan
            // 
            this.txtPerusahaan.Location = new System.Drawing.Point(205, 302);
            this.txtPerusahaan.Name = "txtPerusahaan";
            this.txtPerusahaan.ReadOnly = true;
            this.txtPerusahaan.Size = new System.Drawing.Size(229, 22);
            this.txtPerusahaan.TabIndex = 11;
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Location = new System.Drawing.Point(597, 258);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(174, 36);
            this.btnTampilkan.TabIndex = 12;
            this.btnTampilkan.Text = "Tampilkan Lowongan";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Posisi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Perusahaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Lokasi";
            // 
            // FormLamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.txtPerusahaan);
            this.Controls.Add(this.txtPosisi);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLamar);
            this.Controls.Add(this.label1);
            this.Name = "FormLamar";
            this.Text = "FormLamar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLamar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.TextBox txtPosisi;
        private System.Windows.Forms.TextBox txtPerusahaan;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}