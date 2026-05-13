using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //

namespace PABDUCP1
{
    public partial class FormPerusahaan : Form
    {
        public FormPerusahaan()
        {
            InitializeComponent();
        }

        private void FormPerusahaan_Load(object sender, EventArgs e)
        {
            if (FormLogin.currentRole != "Perusahaan")
            {
                MessageBox.Show("Akses ditolak!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Dashboard Perusahaan";
        }

        private void btnLowongan_Click(object sender, EventArgs e)
        {
            new FormLowonganCRUD().Show();
        }

        private void btnLamaran_Click(object sender, EventArgs e)
        {
            new FormKelolaLamaran().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin.currentPerusahaanID = 0;
            FormLogin.currentRole = "";
            new FormLogin().Show();
            this.Close();
        }
    }
}
