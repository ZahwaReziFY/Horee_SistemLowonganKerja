using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //

namespace PABDUCP1
{
    public partial class FormLowonganCRUD : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormLowonganCRUD()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Lowongan", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Lowongan (ID_Perusahaan,Posisi,Deskripsi,Lokasi) VALUES (@p,@j,@d,@l)", conn);

            cmd.Parameters.AddWithValue("@p", FormLogin.currentPerusahaanID);
            cmd.Parameters.AddWithValue("@j", txtPosisi.Text);
            cmd.Parameters.AddWithValue("@d", txtDeskripsi.Text);
            cmd.Parameters.AddWithValue("@l", txtLokasi.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "UPDATE Lowongan SET Posisi=@j,Deskripsi=@d,Lokasi=@l WHERE ID_Lowongan=@id", conn);

            cmd.Parameters.AddWithValue("@id", txtIDLowongan.Text);
            cmd.Parameters.AddWithValue("@j", txtPosisi.Text);
            cmd.Parameters.AddWithValue("@d", txtDeskripsi.Text);
            cmd.Parameters.AddWithValue("@l", txtLokasi.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "DELETE FROM Lowongan WHERE ID_Lowongan=@id", conn);

            cmd.Parameters.AddWithValue("@id", txtIDLowongan.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtIDLowongan.Text = row.Cells["ID_Lowongan"].Value.ToString();
                txtPosisi.Text = row.Cells["Posisi"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtLokasi.Text = row.Cells["Lokasi"].Value.ToString();
            } //
        }
    }
}