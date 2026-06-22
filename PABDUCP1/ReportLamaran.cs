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
    public partial class ReportLamaran : Form
    {
        public DataTable dtReport { get; set; }
        public ReportLamaran()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.ReportLamaran_Load);
        }

    private void ReportLamaran_Load(object sender, EventArgs e)
        {
            CrystalReport11.SetDataSource(dtReport);
            crystalReportViewer1.ReportSource =CrystalReport11;
        }
    }
}
