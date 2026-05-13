using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//

namespace PABDUCP1
{
    public partial class FormKelolaLamaran : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        public FormKelolaLamaran()
        {
            InitializeComponent();

            // TAMBAHKAN BARIS INI:
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }

        private void FormKelolaLamaran_Load(object sender, EventArgs e)
        {
            // Batasan role
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Kelola Lamaran";
            LoadData();
        }

        void LoadData()
        {
            try
            {
                string query = @"
            SELECT 
                L.ID_Lamaran, 
                U.Nama AS Nama_Pelamar, 
                U.Email AS Email_Pelamar, 
                LW.Posisi, 
                L.TanggalLamaran, 
                L.Status
            FROM Lamaran L
            JOIN Users U ON L.ID_User = U.ID_User
            JOIN Lowongan LW ON L.ID_Lowongan = LW.ID_Lowongan
            WHERE LW.ID_Perusahaan = @pid
            ORDER BY L.TanggalLamaran DESC";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // PASTIKAN FormLogin.currentPerusahaanID tidak 0
                    cmd.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Sembunyikan ID agar rapi tapi tetap bisa diambil nilainya
                    if (dataGridView1.Columns.Contains("ID_Lamaran"))
                        dataGridView1.Columns["ID_Lamaran"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }//

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Diterima")
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (status == "Ditolak")
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIDLamaran.Text = row.Cells["ID_Lamaran"].Value?.ToString();
            }
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            UpdateStatus("Diterima");
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            UpdateStatus("Ditolak");
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            UpdateStatus("Pending");
        }

        void UpdateStatus(string status)
        {
            if (txtIDLamaran.Text.Trim() == "")
            {
                MessageBox.Show("Pilih lamaran dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateStatusLamaran", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Lamaran", Convert.ToInt32(txtIDLamaran.Text));
                    cmd.Parameters.AddWithValue("@StatusBaru", status);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Status lamaran berhasil diubah ke: " + status, "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                txtIDLamaran.Text = "";
            }
            catch (SqlException ex)
            {
                // Tangkap RAISERROR dari SP (misal: tidak bisa kembalikan ke Pending)
                MessageBox.Show(ex.Message, "Gagal Update Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}