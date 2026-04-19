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

        private void btnLihat_Click(object sender, EventArgs e)
        {
            new FormLowonganView().Show();
        }

        private void btnLamar_Click(object sender, EventArgs e)
        {
            new FormLamar().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Close();
        }

    }
}
