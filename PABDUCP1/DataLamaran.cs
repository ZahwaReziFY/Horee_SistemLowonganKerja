using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PABDUCP1
{
    internal class DataLamaran
    {
        public int ID_Lamaran { get; set; }
        public string Nama_Pelamar { get; set; }
        public string Email_Pelamar { get; set; }
        public string Posisi { get; set; }
        public string Nama_Perusahaan { get; set; }
        public DateTime TanggalLamaran { get; set; }
        public string Status { get; set; }
    }
}
