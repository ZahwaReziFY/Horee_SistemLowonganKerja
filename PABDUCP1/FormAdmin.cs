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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            new FormUserCRUD().Show();
        }

        private void btnLowongan_Click(object sender, EventArgs e)
        {
            new FormLowonganCRUD().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }
    }
}
