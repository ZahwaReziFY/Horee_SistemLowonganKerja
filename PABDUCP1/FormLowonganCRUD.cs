using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //

namespace PABDUCP1
{
    public partial class FormLowonganCRUD : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        // BindingSource menghubungkan DataTable ke DataGridView & Navigator
        private BindingSource bindingSource = new BindingSource();

        public FormLowonganCRUD()
        {
            InitializeComponent();
            bindingSource = lowonganBindingSource;
        }

        private void FormLowonganCRUD_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Hubungkan BindingNavigator ke BindingSource
            bindingNavigator1.BindingSource = lowonganBindingSource;

            // Nonaktifkan tombol tambah/hapus bawaan Navigator (kita punya tombol sendiri)
            if (bindingNavigatorAddNewItem != null) bindingNavigatorAddNewItem.Enabled = false;
            if (bindingNavigatorDeleteItem != null) bindingNavigatorDeleteItem.Enabled = false;

            LoadData();
        }

        // ── Load data dari VIEW vw_LowonganPerusahaan ─────────────────
        void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ID_Lowongan, Posisi, Deskripsi, Lokasi FROM vw_LowonganPerusahaan WHERE ID_Perusahaan = @pid",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Binding: DataTable → BindingSource → DataGridView & Navigator
                    lowonganBindingSource.DataSource = dt;
                    dataGridView1.DataSource = lowonganBindingSource;

                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dataGridView1.Columns.Contains("ID_Lowongan"))
                        dataGridView1.Columns["ID_Lowongan"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Klik baris → isi textbox ───────────────────────────────────
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtIDLowongan.Text = row.Cells["ID_Lowongan"].Value?.ToString();
            txtPosisi.Text = row.Cells["Posisi"].Value?.ToString();
            txtDeskripsi.Text = row.Cells["Deskripsi"].Value?.ToString();
            txtLokasi.Text = row.Cells["Lokasi"].Value?.ToString();
        }

        // ── BindingSource CurrentChanged: navigasi via Navigator ──────
        private void lowonganBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (lowonganBindingSource.Current == null) return;
            DataRowView row = (DataRowView)lowonganBindingSource.Current;
            txtIDLowongan.Text = row["ID_Lowongan"]?.ToString();
            txtPosisi.Text = row["Posisi"]?.ToString();
            txtDeskripsi.Text = row["Deskripsi"]?.ToString();
            txtLokasi.Text = row["Lokasi"]?.ToString();
        }

        // ── INSERT via sp_InsertLowongan ───────────────────────────────
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtPosisi.Text.Trim() == "" || txtDeskripsi.Text.Trim() == "" ||
                txtLokasi.Text.Trim() == "")
            {
                MessageBox.Show("Posisi, Deskripsi, dan Lokasi harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_InsertLowongan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Perusahaan", FormLogin.currentPerusahaanID);
                    cmd.Parameters.AddWithValue("@Posisi", txtPosisi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Lokasi", txtLokasi.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Lowongan berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── UPDATE via sp_UpdateLowongan ───────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIDLowongan.Text.Trim() == "")
            {
                MessageBox.Show("Pilih lowongan dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateLowongan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Lowongan", Convert.ToInt32(txtIDLowongan.Text));
                    cmd.Parameters.AddWithValue("@ID_Perusahaan", FormLogin.currentPerusahaanID);
                    cmd.Parameters.AddWithValue("@Posisi", txtPosisi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Lokasi", txtLokasi.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Lowongan berhasil diupdate!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── DELETE via sp_DeleteLowongan ───────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIDLowongan.Text.Trim() == "")
            {
                MessageBox.Show("Pilih lowongan dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus lowongan ini?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteLowongan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Lowongan", Convert.ToInt32(txtIDLowongan.Text));
                    cmd.Parameters.AddWithValue("@ID_Perusahaan", FormLogin.currentPerusahaanID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Lowongan berhasil dihapus!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) => LoadData();

        void ClearFields()
        {
            txtIDLowongan.Text = "";
            txtPosisi.Text = "";
            txtDeskripsi.Text = "";
            txtLokasi.Text = "";
        }

        private void FormLowonganCRUD_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemLowonganDBDataSet.Lowongan' table. You can move, or remove it, as needed.
            this.lowonganTableAdapter.Fill(this.sistemLowonganDBDataSet.Lowongan);

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}