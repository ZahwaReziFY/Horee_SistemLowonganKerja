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

        private BindingSource bindingSource = new BindingSource();

        public FormKelolaLamaran()
        {
            InitializeComponent();
        }

        private void FormKelolaLamaran_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Kelola Lamaran";

            bindingNavigator1.BindingSource = bindingSource;
            if (bindingNavigatorAddNewItem != null) bindingNavigatorAddNewItem.Enabled = false;
            if (bindingNavigatorDeleteItem != null) bindingNavigatorDeleteItem.Enabled = false;

            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ID_Lamaran, Nama_Pelamar, Email_Pelamar, Posisi, TanggalLamaran, Status " +
                    "FROM vw_SemuaLamaran WHERE ID_Perusahaan = @pid ORDER BY TanggalLamaran DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@pid", FormLogin.currentPerusahaanID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dataGridView1.Columns.Contains("ID_Lamaran"))
                        dataGridView1.Columns["ID_Lamaran"].Visible = false;

                    WarnaiStatus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void WarnaiStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow || row.Cells["Status"].Value == null) continue;
                string status = row.Cells["Status"].Value.ToString();
                row.DefaultCellStyle.BackColor = status == "Diterima" ? Color.LightGreen
                                               : status == "Ditolak" ? Color.LightCoral
                                               : Color.LightYellow;
            }
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
                return;
            DataRowView row = bindingSource.Current as DataRowView;
            if (row != null)
            {
                txtIDLamaran.Text = row["ID_Lamaran"].ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            bindingSource.Position = e.RowIndex;
            txtIDLamaran.Text = row.Cells["ID_Lamaran"].Value.ToString();
        }
        private void btnAcc_Click(object sender, EventArgs e) => UpdateStatus("Diterima");
        private void btnTolak_Click(object sender, EventArgs e) => UpdateStatus("Ditolak");
        private void btnPending_Click(object sender, EventArgs e) => UpdateStatus("Pending");

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
                MessageBox.Show("Status berhasil diubah ke: " + status, "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ID_Lamaran"].Value.ToString()
                       == txtIDLamaran.Text)
                    {
                        row.Selected = true;
                        dataGridView1.CurrentCell =
                        row.Cells[1];
                        break;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Update Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
    }//
}