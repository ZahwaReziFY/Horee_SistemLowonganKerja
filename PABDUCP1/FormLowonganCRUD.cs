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

        public FormLowonganCRUD()
        {
            InitializeComponent();
        }

        private void FormLowonganCRUD_Load(object sender, EventArgs e)
        {
            // Batasan role
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadData();
        }

        void LoadData()
        {
            try
            {
                // Hanya tampilkan lowongan MILIK perusahaan yang login
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ID_Lowongan, Posisi, Deskripsi, Lokasi FROM Lowongan WHERE ID_Perusahaan = @pid",
                    conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIDLowongan.Text = row.Cells["ID_Lowongan"].Value?.ToString();
                txtPosisi.Text = row.Cells["Posisi"].Value?.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value?.ToString();
                txtLokasi.Text = row.Cells["Lokasi"].Value?.ToString();
            }
        }

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
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Lowongan (ID_Perusahaan, Posisi, Deskripsi, Lokasi) VALUES (@p, @j, @d, @l)",
                    conn))
                {
                    // ID_Perusahaan otomatis dari session — perusahaan lain tidak bisa insert ke slot ini
                    cmd.Parameters.AddWithValue("@p", FormLogin.currentPerusahaanID);
                    cmd.Parameters.AddWithValue("@j", txtPosisi.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@l", txtLokasi.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Lowongan berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIDLowongan.Text == "")
            {
                MessageBox.Show("Pilih lowongan dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    // Tambah WHERE ID_Perusahaan = @pid agar perusahaan A tidak bisa edit milik B
                    "UPDATE Lowongan SET Posisi=@j, Deskripsi=@d, Lokasi=@l WHERE ID_Lowongan=@id AND ID_Perusahaan=@pid",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", txtIDLowongan.Text);
                    cmd.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);
                    cmd.Parameters.AddWithValue("@j", txtPosisi.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@l", txtLokasi.Text.Trim());

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        MessageBox.Show("Update gagal. Lowongan tidak ditemukan atau bukan milik Anda.", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Lowongan berhasil diupdate!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIDLowongan.Text == "")
            {
                MessageBox.Show("Pilih lowongan dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show("Yakin ingin menghapus lowongan ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    // Tambah WHERE ID_Perusahaan = @pid agar perusahaan A tidak bisa hapus milik B
                    "DELETE FROM Lowongan WHERE ID_Lowongan=@id AND ID_Perusahaan=@pid",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@id", txtIDLowongan.Text);
                    cmd.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                        MessageBox.Show("Hapus gagal. Lowongan bukan milik Anda.", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Lowongan berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearFields()
        {
            txtIDLowongan.Text = "";
            txtPosisi.Text = "";
            txtDeskripsi.Text = "";
            txtLokasi.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
