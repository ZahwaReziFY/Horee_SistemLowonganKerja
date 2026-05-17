Skenario Pengujian:
1. Run Visual Studio.
2. Saat di halaman login, pilih regist user / login user (jika sudah mempunyai akun).
3. Saat sudah login, di tampilan dashboard user terdapat 3 pilihan menu, pilih Lihat Lowongan.
4. User akan masuk ke `FormLowonganView`.
5. Pada textbox cari, ketik: ' OR '1'='1 lalu klik tombol Test Injeksi.

Hasil Pengujian:
Data GridView akan tetap menampilkan seluruh data lowongan yang tersedia di dalam database, bukan hanya lowongan yang sesuai dengan kata kunci pencarian biasa.

Kenapa Bisa Berfungsi?:
Inputan ' OR '1'='1 itu berhasil memanipulasi logika query SQL asli di dalam source code yang ada. Karena perintah '1'='1' itu hasilnya selalu benar (True), database dipaksa untuk mengabaikan filter pencarian biasa dan langsung mengeluarkan semua isi tabel lowongan.
