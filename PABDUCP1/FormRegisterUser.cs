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
    public partial class FormRegisterUser : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormRegisterUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "" || txtPassword.Text == "" || txtPassword.Text == "" ||
                txtJalan.Text == "" || txtDesa.Text == "" || txtKabupaten.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!");
                return;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Users (Nama,Email,Password,Jalan,Desa,Kabupaten) VALUES (@n,@e,@p,@j,@d,@k)", conn);

                cmd.Parameters.AddWithValue("@n", txtNama.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@j", txtJalan.Text);
                cmd.Parameters.AddWithValue("@d", txtDesa.Text);
                cmd.Parameters.AddWithValue("@k", txtKabupaten.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registrasi User berhasil!");

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRegisterUser_Load(object sender, EventArgs e)
        {

        }
    }
}