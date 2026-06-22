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

    public partial class FormLowonganView : Form
    {
        string connStr = "Server=tcp:serverpabdwawa.database.windows.net,1433;Initial Catalog=SistemLowonganDB;User ID=zahwarzfy;Password=Zahwaa04;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private BindingSource bindingSource = new BindingSource();

        public FormLowonganView()
        {
            InitializeComponent();
        }

        private void FormLowonganView_Load(object sender, EventArgs e)
        {
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
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_LowonganTersedia", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCariSafe_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM vw_LowonganTersedia WHERE Posisi LIKE @cari OR Nama_Perusahaan LIKE @cari",conn))
                {
                    cmd.Parameters.Add("@cari",
                    SqlDbType.VarChar, 100)
                    .Value =
                    "%" + txtCari.Text.Trim() + "%";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bindingSource.DataSource = dt;

                    lblWarning.Text = "✅ SAFE : Parameterized Query";

                    lblWarning.ForeColor =
                    Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCari.Text = "";
            lblWarning.Text = "";
            LoadData();
        }

        private void btnCariSP_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_SearchLowongan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cari", txtCari.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bindingSource.DataSource = dt;

                    lblWarning.Text = "✅ Pencarian via Stored Procedure.";
                    lblWarning.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}