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
        private BindingSource bindingSource = new BindingSource();

        public FormLamar()
        {
            InitializeComponent();

            bindingSource = vwLowonganTersediaBindingSource;
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

            // Hubungkan Navigator ke BindingSource
            bindingNavigator1.BindingSource = bindingSource;
            if (bindingNavigatorAddNewItem != null) bindingNavigatorAddNewItem.Enabled = false;
            if (bindingNavigatorDeleteItem != null) bindingNavigatorDeleteItem.Enabled = false;

            // Sync textbox saat navigator bergerak
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            LoadLowongan();
        }

        void LoadLowongan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT LW.ID_Lowongan, LW.Posisi, P.Nama_Perusahaan, LW.Lokasi, LW.Deskripsi
                      FROM Lowongan LW
                      JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan
                      WHERE LW.ID_Lowongan NOT IN (
                          SELECT ID_Lowongan FROM Lamaran WHERE ID_User = @uid
                      )", conn))
                {
                    cmd.Parameters.AddWithValue("@uid", FormLogin.currentUserID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dataGridView1.Columns.Contains("ID_Lowongan"))
                        dataGridView1.Columns["ID_Lowongan"].Visible = false;

                    // Reset pilihan
                    selectedIDLowongan = 0;
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lowongan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;
            DataRowView row = (DataRowView)bindingSource.Current;
            selectedIDLowongan = Convert.ToInt32(row["ID_Lowongan"]);
            txtPosisi.Text = row["Posisi"]?.ToString();
            txtPerusahaan.Text = row["Nama_Perusahaan"]?.ToString();
            txtLokasi.Text = row["Lokasi"]?.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            bindingSource.Position = e.RowIndex; // trigger CurrentChanged otomatis
        }

        private void btnLamar_Click(object sender, EventArgs e)
        {
            if (selectedIDLowongan == 0)
            {
                MessageBox.Show("Pilih lowongan dari tabel dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_InsertLamaran", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_User", FormLogin.currentUserID);
                    cmd.Parameters.AddWithValue("@ID_Lowongan", selectedIDLowongan);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Lamaran berhasil dikirim! Status: Pending.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Melamar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            LoadLowongan();
            MessageBox.Show("Data lowongan terbaru telah dimuat.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void ClearFields()
        {
            txtPosisi.Text = "";
            txtPerusahaan.Text = "";
            txtLokasi.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}