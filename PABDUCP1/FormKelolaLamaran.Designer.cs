namespace PABDUCP1
{
    partial class FormKelolaLamaran
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
            this.btnTolak = new System.Windows.Forms.Button();
            this.btnAcc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDLamaran = new System.Windows.Forms.TextBox();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTolak
            // 
            this.btnTolak.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnTolak.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTolak.Location = new System.Drawing.Point(522, 392);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(113, 35);
            this.btnTolak.TabIndex = 1;
            this.btnTolak.Text = "Tolak";
            this.btnTolak.UseVisualStyleBackColor = false;
            this.btnTolak.Click += new System.EventHandler(this.btnTolak_Click);
            // 
            // btnAcc
            // 
            this.btnAcc.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAcc.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcc.Location = new System.Drawing.Point(326, 392);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(113, 35);
            this.btnAcc.TabIndex = 2;
            this.btnAcc.Text = "ACC";
            this.btnAcc.UseVisualStyleBackColor = false;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tampilkan ID";
            // 
            // txtIDLamaran
            // 
            this.txtIDLamaran.Location = new System.Drawing.Point(403, 332);
            this.txtIDLamaran.Name = "txtIDLamaran";
            this.txtIDLamaran.Size = new System.Drawing.Size(141, 22);
            this.txtIDLamaran.TabIndex = 4;
            // 
            // btnPending
            // 
            this.btnPending.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnPending.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPending.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPending.Location = new System.Drawing.Point(158, 392);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(113, 35);
            this.btnPending.TabIndex = 5;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = false;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLoad.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(137, 105);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(168, 39);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Tampilkan data";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.FormKelolaLamaran_Load);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Sienna;
            this.dataGridView1.Location = new System.Drawing.Point(128, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(548, 150);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LavenderBlush;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 78);
            this.label2.TabIndex = 8;
            this.label2.Text = "DATA LAMARAN";
            // 
            // FormKelolaLamaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.txtIDLamaran);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAcc);
            this.Controls.Add(this.btnTolak);
            this.Name = "FormKelolaLamaran";
            this.Text = "FormLamaran";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTolak;
        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDLamaran;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}