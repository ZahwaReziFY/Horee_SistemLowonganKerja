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
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public static int currentUserID;
        public static int currentPerusahaanID;
        public static string currentRole;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();

            string query = @"
            SELECT ID_User as ID, 'User' as Role FROM Users WHERE Email=@u AND Password=@p
            UNION
            SELECT ID_Perusahaan, 'Perusahaan' FROM Perusahaan WHERE Email=@u AND Password=@p
            UNION
            SELECT ID_Admin, 'Admin' FROM Admin WHERE Username=@u AND Password=@p";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                currentRole = rd["Role"].ToString();

                if (currentRole == "User")
                {
                    currentUserID = Convert.ToInt32(rd["ID"]);
                    new FormUser().Show();
                }
                else if (currentRole == "Perusahaan")
                {
                    currentPerusahaanID = Convert.ToInt32(rd["ID"]);
                    new FormPerusahaan().Show();
                }
                else
                {
                    new FormAdmin().Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Login gagal!");
            }

            conn.Close();

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
