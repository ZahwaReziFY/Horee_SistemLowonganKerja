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
    public partial class FormRegisterPerusahaan : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormRegisterPerusahaan()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" ||
                txtJalan.Text == "" || txtKabupaten.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Perusahaan (Nama_Perusahaan,Email,Password,Jalan,Kabupaten) VALUES (@n,@e,@p,@j,@k)", conn);

                cmd.Parameters.AddWithValue("@n", txtNama.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@j", txtJalan.Text);
                cmd.Parameters.AddWithValue("@k", txtKabupaten.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registrasi Perusahaan berhasil!");

                new FormLogin().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }
    }
}
