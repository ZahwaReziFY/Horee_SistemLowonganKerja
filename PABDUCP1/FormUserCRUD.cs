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
    public partial class FormUserCRUD : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormUserCRUD()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(
            "UPDATE Users SET Nama=@n,Email=@e WHERE ID_User=@id", conn);

            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@n", txtNama.Text);
            cmd.Parameters.AddWithValue("@e", txtEmail.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Yakin hapus?", "Konfirmasi", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE ID_User=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT * FROM Users WHERE Nama LIKE @s", conn);

            da.SelectCommand.Parameters.AddWithValue("@s", "%" + txtSearch.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["ID_User"].Value.ToString();
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }//
        }
    }
}