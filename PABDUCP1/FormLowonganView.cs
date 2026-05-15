using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //

namespace PABDUCP1
{
    // ================================================================
    // FormLowonganView — Tampilan lowongan untuk semua orang
    //
    // ⚠️  SENGAJA MENGANDUNG SQL INJECTION pada kolom pencarian
    //     untuk tujuan demonstrasi / pembelajaran.
    //     Lihat README_SQLInjection.md untuk skenario lengkap.
    // ================================================================
    public partial class FormLowonganView : Form
    {
        private readonly string connStr =
            "Data Source=WAWAAA\\ZAHWA;Initial Catalog=SistemLowonganDB;Integrated Security=True";

        private BindingSource bindingSource = new BindingSource();

        public FormLowonganView()
        {
            InitializeComponent();
        }

        private void FormLowonganView_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bindingSource;
            if (bindingNavigatorAddNewItem != null) bindingNavigatorAddNewItem.Enabled = false;
            if (bindingNavigatorDeleteItem != null) bindingNavigatorDeleteItem.Enabled = false;

            LoadData();
        }

        // ── Load semua lowongan dari VIEW ──────────────────────────────
        void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_LowonganTersedia", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCariVulnerable_Click(object sender, EventArgs e)
        {
            string input = txtCari.Text; // ← TIDAK di-sanitasi, langsung pakai

            // ⚠️ BERBAHAYA: string concatenation langsung
            string queryVulnerable =
                "SELECT * FROM vw_LowonganTersedia WHERE Posisi LIKE '%" + input + "%'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlDataAdapter da = new SqlDataAdapter(queryVulnerable, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bindingSource.DataSource = dt;

                    // Tampilkan peringatan demo
                    lblWarning.Text = "⚠️ Mode VULNERABLE aktif! Query: " + queryVulnerable;
                    lblWarning.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Jika query rusak karena injeksi, error akan muncul di sini
                MessageBox.Show("SQL Error (mungkin karena injeksi): " + ex.Message,
                    "SQL Injection Detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblWarning.Text = "Error: " + ex.Message;
            }
        }

        // ================================================================
        // ✅  SAFE — Menggunakan Parameterized Query (cara yang benar)
        //     Input dimasukkan sebagai parameter, bukan sambung string.
        // ================================================================
        private void btnCariSafe_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM vw_LowonganTersedia WHERE Posisi LIKE @cari OR Nama_Perusahaan LIKE @cari",
                    conn))
                {
                    // ✅ AMAN: input diperlakukan sebagai nilai, bukan bagian query
                    cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bindingSource.DataSource = dt;

                    lblWarning.Text = "✅ Mode SAFE aktif — parameterized query digunakan.";
                    lblWarning.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCari.Text = "";
            lblWarning.Text = "";
            LoadData();
        }
    }
}