using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //

namespace PABDUCP1
{
    public partial class FormLamar : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        private int selectedIDLowongan = 0;

        public FormLamar()
        {
            InitializeComponent();
        }

        private void FormLamar_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "User")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Hapus atau beri komentar pada baris yang error ini:
            // txtIDUser.Text = FormLogin.currentUserID.ToString(); 

            LoadLowongan();
        }

        void LoadLowongan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Query ini mengambil lowongan yang BELUM dilamar oleh user ini
                    string query = @"
                SELECT LW.ID_Lowongan, 
                       LW.Posisi, 
                       P.Nama_Perusahaan,
                       LW.Lokasi
                FROM Lowongan LW
                JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan
                WHERE LW.ID_Lowongan NOT IN (
                    SELECT ID_Lowongan FROM Lamaran 
                    WHERE ID_User = @uid
                )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", FormLogin.currentUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Pengaturan GridView agar rapi
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (dataGridView1.Columns.Contains("ID_Lowongan"))
                        dataGridView1.Columns["ID_Lowongan"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            LoadLowongan();
            MessageBox.Show("Data lowongan terbaru telah dimuat.", "Info");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Simpan ID ke variabel (bukan ke TextBox)
                selectedIDLowongan = Convert.ToInt32(row.Cells["ID_Lowongan"].Value);

                // Tampilkan yang penting-penting saja ke user
                txtPosisi.Text = row.Cells["Posisi"].Value.ToString();
                txtPerusahaan.Text = row.Cells["Nama_Perusahaan"].Value.ToString();
                txtLokasi.Text = row.Cells["Lokasi"].Value.ToString();
            }
        }

        private void btnLamar_Click(object sender, EventArgs e)
        {
            if (selectedIDLowongan == 0)
            {
                MessageBox.Show("Pilih lowongan dulu dari tabel!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_InsertLamaran", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ambil langsung dari variabel Global di FormLogin dan variabel selected
                    cmd.Parameters.AddWithValue("@ID_User", FormLogin.currentUserID);
                    cmd.Parameters.AddWithValue("@ID_Lowongan", selectedIDLowongan);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Lamaran Berhasil!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal: " + ex.Message);
            }
        }
    }
}