using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PABDUCP1
{
    public partial class FormRekapData : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        public DataTable dtReport = new DataTable();

        public FormRekapData()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormRekapData_Load);
        }

        private void FormRekapData_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }
            dtpTahun.Format = DateTimePickerFormat.Custom;
            dtpTahun.CustomFormat = "yyyy";
            dtpTahun.ShowUpDown = true;

            LoadPosisi();

            dgvRekap.ReadOnly = true;
            dgvRekap.AllowUserToAddRows = false;
            dgvRekap.AllowUserToDeleteRows = false;
            dgvRekap.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPosisi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"SELECT DISTINCT Posisi FROM Lowongan WHERE ID_Perusahaan=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", FormLogin.currentPerusahaanID);
                    conn.Open();

                    MessageBox.Show("ID Perusahaan: " + FormLogin.currentPerusahaanID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    MessageBox.Show("Jumlah posisi ditemukan: " + dt.Rows.Count);

                    cmbPosisi.DataSource = dt;
                    cmbPosisi.DisplayMember = "Posisi";
                    cmbPosisi.ValueMember = "Posisi";  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadPosisi: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query =
                    @"
                    SELECT
                        L.ID_Lamaran,
                        U.Nama AS Nama_Pelamar,
                        U.Email AS Email_Pelamar,
                        LW.Posisi,
                        LW.Lokasi,
                        L.TanggalLamaran,
                        L.Status

                    FROM Lamaran L

                    INNER JOIN Users U
                    ON L.ID_User = U.ID_User

                    INNER JOIN Lowongan LW
                    ON L.ID_Lowongan = LW.ID_Lowongan

                    WHERE LW.ID_Perusahaan=@id
                    AND LW.Posisi=@posisi
                    AND YEAR(L.TanggalLamaran)=@tahun

                    ORDER BY L.TanggalLamaran DESC
                    ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue(
                        "@id", FormLogin.currentPerusahaanID);
                    cmd.Parameters.AddWithValue(
                        "@posisi", cmbPosisi.Text);
                    cmd.Parameters.AddWithValue(
                        "@tahun", dtpTahun.Value.Year);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtReport.Clear();
                    da.Fill(dtReport);
                    dgvRekap.DataSource = dtReport;
                    if (dtReport.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data lamaran ditemukan.", "Info");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data : " + ex.Message);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Load data terlebih dahulu.");
                return;
            }
            ReportLamaran rpt = new ReportLamaran();
            rpt.dtReport = dtReport; 
            rpt.Show();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
