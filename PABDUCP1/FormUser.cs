using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PABDUCP1
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            // Pastikan yang masuk adalah User
            if (FormLogin.currentRole != "User")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Dashboard User";
        }

        private void btnLihat_Click(object sender, EventArgs e)
        {
            new FormLowonganView().Show();
        }

        private void btnLamar_Click(object sender, EventArgs e)
        {
            new FormLamar().Show();
        }

        // Tombol untuk melihat status lamaran milik user ini
        private void btnStatusLamaran_Click(object sender, EventArgs e)
        {
            new FormStatusLamaran().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin.currentUserID = 0;
            FormLogin.currentRole = "";
            new FormLogin().Show();
            this.Close();
        }

        private void FormUser_Load_1(object sender, EventArgs e)
        {

        }
    }
}