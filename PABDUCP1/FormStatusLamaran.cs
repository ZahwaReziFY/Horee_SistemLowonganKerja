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

        private BindingSource bindingSource = new BindingSource();

        private void FormStatusLamaran_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "User")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Status Lamaran Saya";

            // Hubungkan Navigator
            bindingNavigator1.BindingSource = bindingSource;
            if (bindingNavigatorAddNewItem != null) bindingNavigatorAddNewItem.Enabled = false;
            if (bindingNavigatorDeleteItem != null) bindingNavigatorDeleteItem.Enabled = false;

            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ID_Lamaran, Posisi, Nama_Perusahaan, TanggalLamaran, Status " +
                    "FROM vw_SemuaLamaran WHERE ID_User = @uid ORDER BY TanggalLamaran DESC", conn))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}