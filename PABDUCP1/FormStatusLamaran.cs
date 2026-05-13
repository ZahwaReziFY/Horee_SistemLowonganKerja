using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PABDUCP1
{
    public partial class FormStatusLamaran : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        public FormStatusLamaran()
        {
            InitializeComponent();
        }

        private void FormStatusLamaran_Load(object sender, EventArgs e)
        {
            // Batasan role
            if (FormLogin.currentRole != "User")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Status Lamaran Saya";
            LoadData();
        }

        void LoadData()
        {
            try
            {
                // Hanya tampilkan lamaran milik user yang sedang login
                string query = @"
                    SELECT 
                        L.ID_Lamaran,
                        LW.Posisi,
                        P.Nama_Perusahaan,
                        LW.Lokasi,
                        L.TanggalLamaran,
                        L.Status
                    FROM Lamaran L
                    JOIN Lowongan LW ON L.ID_Lowongan = LW.ID_Lowongan
                    JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan
                    WHERE L.ID_User = @uid
                    ORDER BY L.TanggalLamaran DESC";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", FormLogin.currentUserID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;

                    
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string status = row.Cells["Status"].Value?.ToString();
                        if (status == "Diterima")
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        else if (status == "Ditolak")
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        else
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}