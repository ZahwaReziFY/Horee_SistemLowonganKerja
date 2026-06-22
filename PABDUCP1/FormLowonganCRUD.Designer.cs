namespace PABDUCP1
{
    partial class FormLowonganCRUD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLowonganCRUD));
            this.txtIDLowongan = new System.Windows.Forms.TextBox();
            this.lowonganBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemLowonganDBDataSet = new PABDUCP1.SistemLowonganDBDataSet();
            this.txtPosisi = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRekapData = new System.Windows.Forms.Button();
            this.lowonganTableAdapter = new PABDUCP1.SistemLowonganDBDataSetTableAdapters.LowonganTableAdapter();
            this.btnImpDB = new System.Windows.Forms.Button();
            this.btnImpExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lowonganBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemLowonganDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDLowongan
            // 
            this.txtIDLowongan.BackColor = System.Drawing.Color.Azure;
            this.txtIDLowongan.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lowonganBindingSource, "ID_Lowongan", true));
            this.txtIDLowongan.Location = new System.Drawing.Point(181, 37);
            this.txtIDLowongan.Name = "txtIDLowongan";
            this.txtIDLowongan.Size = new System.Drawing.Size(42, 22);
            this.txtIDLowongan.TabIndex = 0;
            // 
            // lowonganBindingSource
            // 
            this.lowonganBindingSource.DataMember = "Lowongan";
            this.lowonganBindingSource.DataSource = this.sistemLowonganDBDataSet;
            this.lowonganBindingSource.CurrentChanged += new System.EventHandler(this.lowonganBindingSource_CurrentChanged);
            // 
            // sistemLowonganDBDataSet
            // 
            this.sistemLowonganDBDataSet.DataSetName = "SistemLowonganDBDataSet";
            this.sistemLowonganDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtPosisi
            // 
            this.txtPosisi.BackColor = System.Drawing.Color.Azure;
            this.txtPosisi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lowonganBindingSource, "Posisi", true));
            this.txtPosisi.Location = new System.Drawing.Point(181, 79);
            this.txtPosisi.Name = "txtPosisi";
            this.txtPosisi.Size = new System.Drawing.Size(310, 22);
            this.txtPosisi.TabIndex = 1;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.BackColor = System.Drawing.Color.Azure;
            this.txtDeskripsi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lowonganBindingSource, "Deskripsi", true));
            this.txtDeskripsi.Location = new System.Drawing.Point(181, 119);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(310, 22);
            this.txtDeskripsi.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Sienna;
            this.dataGridView1.Location = new System.Drawing.Point(54, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(684, 159);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Lavender;
            this.btnLoad.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(570, 36);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(168, 36);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Tampilkan Data";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Lavender;
            this.btnInsert.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(570, 79);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(168, 33);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Lavender;
            this.btnUpdate.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(570, 118);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(168, 36);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Lavender;
            this.btnDelete.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(570, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 36);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label1.Location = new System.Drawing.Point(73, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label2.Location = new System.Drawing.Point(63, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 44);
            this.label2.TabIndex = 9;
            this.label2.Text = "Posisi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(46, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 44);
            this.label3.TabIndex = 10;
            this.label3.Text = "Deskripsi";
            // 
            // txtLokasi
            // 
            this.txtLokasi.BackColor = System.Drawing.Color.Azure;
            this.txtLokasi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lowonganBindingSource, "Lokasi", true));
            this.txtLokasi.Location = new System.Drawing.Point(181, 160);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(148, 22);
            this.txtLokasi.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label4.Location = new System.Drawing.Point(59, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 44);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lokasi";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.lowonganBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(800, 27);
            this.bindingNavigator1.TabIndex = 13;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.lowonganBindingSource_CurrentChanged);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.IndianRed;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(0, 418);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 31);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRekapData
            // 
            this.btnRekapData.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnRekapData.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRekapData.Location = new System.Drawing.Point(570, 202);
            this.btnRekapData.Name = "btnRekapData";
            this.btnRekapData.Size = new System.Drawing.Size(168, 36);
            this.btnRekapData.TabIndex = 15;
            this.btnRekapData.Text = "Rekap Data";
            this.btnRekapData.UseVisualStyleBackColor = false;
            this.btnRekapData.Click += new System.EventHandler(this.btnRekapData_Click);
            // 
            // lowonganTableAdapter
            // 
            this.lowonganTableAdapter.ClearBeforeFill = true;
            // 
            // btnImpDB
            // 
            this.btnImpDB.BackColor = System.Drawing.Color.Lavender;
            this.btnImpDB.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpDB.Location = new System.Drawing.Point(379, 163);
            this.btnImpDB.Name = "btnImpDB";
            this.btnImpDB.Size = new System.Drawing.Size(168, 36);
            this.btnImpDB.TabIndex = 16;
            this.btnImpDB.Text = "Import Database";
            this.btnImpDB.UseVisualStyleBackColor = false;
            this.btnImpDB.Click += new System.EventHandler(this.btnImpDb_Click);
            // 
            // btnImpExcel
            // 
            this.btnImpExcel.BackColor = System.Drawing.Color.Lavender;
            this.btnImpExcel.Font = new System.Drawing.Font("Sans Serif Collection", 7.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpExcel.Location = new System.Drawing.Point(379, 201);
            this.btnImpExcel.Name = "btnImpExcel";
            this.btnImpExcel.Size = new System.Drawing.Size(168, 36);
            this.btnImpExcel.TabIndex = 17;
            this.btnImpExcel.Text = "Import Excel";
            this.btnImpExcel.UseVisualStyleBackColor = false;
            this.btnImpExcel.Click += new System.EventHandler(this.btnImpExcel_Click);
            // 
            // FormLowonganCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImpExcel);
            this.Controls.Add(this.btnImpDB);
            this.Controls.Add(this.btnRekapData);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.txtPosisi);
            this.Controls.Add(this.txtIDLowongan);
            this.Name = "FormLowonganCRUD";
            this.Text = "FormLowonganCRUD";
            ((System.ComponentModel.ISupportInitialize)(this.lowonganBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemLowonganDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDLowongan;
        private System.Windows.Forms.TextBox txtPosisi;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private SistemLowonganDBDataSet sistemLowonganDBDataSet;
        private System.Windows.Forms.BindingSource lowonganBindingSource;
        private SistemLowonganDBDataSetTableAdapters.LowonganTableAdapter lowonganTableAdapter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRekapData;
        private System.Windows.Forms.Button btnImpDB;
        private System.Windows.Forms.Button btnImpExcel;
    }
}