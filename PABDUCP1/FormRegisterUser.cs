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
    public partial class FormRegisterUser : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        public FormRegisterUser()
        {
            InitializeComponent();
        }//

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string jalan = txtJalan.Text.Trim();
            string desa = txtDesa.Text.Trim();
            string kabupaten = txtKabupaten.Text.Trim();


            // 1. Semua wajib diisi
            if (nama == "" || email == "" || password == "" ||
                jalan == "" || desa == "" || kabupaten == "")
            {
                MessageBox.Show("Semua kolom harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Nama: hanya huruf dan spasi
            if (!Regex.IsMatch(nama, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama hanya boleh berisi huruf!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Email: harus mengandung '@' dan format dasar
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Format email tidak valid! Harus mengandung '@'.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Password minimal 8 karakter
            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Jalan, Desa, Kabupaten: tidak boleh angka saja (harus ada huruf)
            if (!Regex.IsMatch(jalan, @"[a-zA-Z]"))
            {
                MessageBox.Show("Jalan tidak boleh berisi angka saja!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(desa, @"[a-zA-Z]"))
            {
                MessageBox.Show("Desa tidak boleh berisi angka saja!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(kabupaten, @"[a-zA-Z]"))
            {
                MessageBox.Show("Kabupaten tidak boleh berisi angka saja!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Panggil Stored Procedure sp_RegisterUser ──────────────────
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Jalan", jalan);
                    cmd.Parameters.AddWithValue("@Desa", desa);
                    cmd.Parameters.AddWithValue("@Kabupaten", kabupaten);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registrasi User berhasil! Silakan login.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                new FormLogin().Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                // Pesan error dari RAISERROR di SP
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
