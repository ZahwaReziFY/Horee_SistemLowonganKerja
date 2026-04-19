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
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormKelolaLamaran()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void FormKelolaLamaran_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT ID_Lamaran, ID_User, ID_Lowongan, Status, TanggalLamaran 
            FROM Lamaran", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIDLamaran.Text = row.Cells["ID_Lamaran"].Value.ToString();
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
            if (txtIDLamaran.Text == "")
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE Lamaran SET Status=@s WHERE ID_Lamaran=@id", conn);

            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", txtIDLamaran.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
            MessageBox.Show("Status berhasil diupdate!");
        }

     
    }
}