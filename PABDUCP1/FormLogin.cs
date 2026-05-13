using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//

namespace PABDUCP1
{
    public partial class FormLogin : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        public static int currentUserID = 0;
        public static int currentPerusahaanID = 0;
        public static string currentRole = "";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username/Email dan Password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }//

            // Query UNION: cek User (Email) dan Perusahaan (Email)
            // Admin dihilangkan sesuai permintaan
            string query = @"
                SELECT ID_User AS ID, 'User' AS Role
                FROM Users
                WHERE Email = @u AND Password = @p
 
                UNION
 
                SELECT ID_Perusahaan, 'Perusahaan'
                FROM Perusahaan
                WHERE Email = @u AND Password = @p";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        currentRole = rd["Role"].ToString();

                        if (currentRole == "User")
                        {
                            currentUserID = Convert.ToInt32(rd["ID"]);
                            currentPerusahaanID = 0;
                            rd.Close();
                            new FormUser().Show();
                        }
                        else if (currentRole == "Perusahaan")
                        {
                            currentPerusahaanID = Convert.ToInt32(rd["ID"]);
                            currentUserID = 0;
                            rd.Close();
                            new FormPerusahaan().Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email atau Password salah!", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            new FormRegisterUser().Show();
            this.Hide();
        }

        private void btnRegisterPerusahaan_Click(object sender, EventArgs e)
        {
            new FormRegisterPerusahaan().Show();
            this.Hide();
        }
    }
}
