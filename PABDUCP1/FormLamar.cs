using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PABDUCP1
{
    public partial class FormLamar : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormLamar()
        {
            InitializeComponent();
        }
        private void btnLamar_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Lamaran (ID_User, ID_Lowongan) VALUES (@u, @l)", conn);

            cmd.Parameters.AddWithValue("@u", txtIDUser.Text);
            cmd.Parameters.AddWithValue("@l", txtIDLowongan.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Lamaran berhasil!");
        }
    }
}
