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
    public partial class FormLowonganView : Form
    {
        SqlConnection conn = new SqlConnection(
        "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True");

        public FormLowonganView()
        {
            InitializeComponent();
        }

        private void FormLowonganView_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Lowongan", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            dataGridView1.ReadOnly = true;
        }
    }
}
