using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//

namespace PABDUCP1
{
    public partial class FormKoneksi : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormKoneksi()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal: " + ex.Message);
            }//
        }
    }
}
