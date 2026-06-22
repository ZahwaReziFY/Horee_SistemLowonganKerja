using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; 


namespace PABDUCP1
{
    public partial class FormRegisterPerusahaan : Form
    {
        string connStr = "Server=tcp:serverpabdwawa.database.windows.net,1433;Initial Catalog=SistemLowonganDB;User ID=zahwarzfy;Password=Zahwaa04;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public FormRegisterPerusahaan()
        {
            InitializeComponent();
        }//

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string alamat = txtAlamat.Text.Trim(); 

            if (nama == "" || email == "" || password == "" || alamat == "")
            {
                MessageBox.Show("Semua kolom harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(nama, @"[a-zA-Z]"))
            {
                MessageBox.Show("Nama Perusahaan tidak valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Format email tidak valid! Harus mengandung '@'.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(alamat, @"[a-zA-Z]"))
            {
                MessageBox.Show("Alamat tidak valid! Tidak boleh angka saja.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_RegisterPerusahaan", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NamaPT", nama);
                    cmd.Parameters.AddWithValue("@EmailPT", email);
                    cmd.Parameters.AddWithValue("@PasswordPT", password);
                    cmd.Parameters.AddWithValue("@AlamatPT", alamat);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registrasi Perusahaan berhasil! Silakan login.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                new FormLogin().Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Gagal Registrasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }
    }
}
