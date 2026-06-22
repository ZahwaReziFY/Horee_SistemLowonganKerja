USE SistemLowonganDB;
GO

CREATE TABLE Users (
    ID_User     INT IDENTITY(1,1) PRIMARY KEY,
    Nama        VARCHAR(100) NOT NULL,
    Email       VARCHAR(100) UNIQUE NOT NULL,
    Password    VARCHAR(255) NOT NULL,
    Jalan       VARCHAR(100) NOT NULL,
    Desa        VARCHAR(100) NOT NULL,
    Kabupaten   VARCHAR(100) NOT NULL
);

CREATE TABLE Perusahaan (
    ID_Perusahaan   INT IDENTITY(1,1) PRIMARY KEY,
    Nama_Perusahaan VARCHAR(100) UNIQUE NOT NULL,
    Email           VARCHAR(100) UNIQUE NOT NULL,
    Password        VARCHAR(255) NOT NULL,
    Alamat          VARCHAR(MAX) NOT NULL
);

CREATE TABLE Lowongan (
    ID_Lowongan   INT IDENTITY(1,1) PRIMARY KEY,
    ID_Perusahaan INT NOT NULL,
    Posisi        VARCHAR(100) NOT NULL,
    Deskripsi     TEXT,
    Lokasi        VARCHAR(100),
    CONSTRAINT FK_Lowongan_Perusahaan FOREIGN KEY (ID_Perusahaan) REFERENCES Perusahaan(ID_Perusahaan)
);

CREATE TABLE Lamaran (
    ID_Lamaran    INT IDENTITY(1,1) PRIMARY KEY,
    ID_User       INT NOT NULL,
    ID_Lowongan   INT NOT NULL,
    TanggalLamaran DATETIME DEFAULT GETDATE(),
    Status        VARCHAR(20) DEFAULT 'Pending',
    CONSTRAINT FK_Lamaran_User    FOREIGN KEY (ID_User)     REFERENCES Users(ID_User),
    CONSTRAINT FK_Lamaran_Lowongan FOREIGN KEY (ID_Lowongan) REFERENCES Lowongan(ID_Lowongan)
);

-- VIEW 1: Semua lowongan tersedia (dipakai FormLowonganView & FormLamar)
CREATE VIEW vw_LowonganTersedia AS
SELECT
    LW.ID_Lowongan,
    LW.Posisi,
    P.Nama_Perusahaan,
    LW.Lokasi,
    LW.Deskripsi,
    P.ID_Perusahaan,
    LW.Posisi + ' - ' + P.Nama_Perusahaan AS Tampilan
FROM Lowongan LW
JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan;
GO

-- VIEW 2: Semua lamaran lengkap (dipakai FormKelolaLamaran)
CREATE VIEW vw_SemuaLamaran AS
SELECT
    L.ID_Lamaran,
    U.Nama        AS Nama_Pelamar,
    U.Email       AS Email_Pelamar,
    LW.Posisi,
    P.Nama_Perusahaan,
    L.TanggalLamaran,
    L.Status,
    L.ID_User,
    LW.ID_Perusahaan
FROM Lamaran L
JOIN Users    U  ON L.ID_User     = U.ID_User
JOIN Lowongan LW ON L.ID_Lowongan = LW.ID_Lowongan
JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan;
GO

SELECT * FROM vw_SemuaLamaran;

-- VIEW 3: Lowongan per perusahaan (dipakai FormLowonganCRUD)
CREATE VIEW vw_LowonganPerusahaan AS
SELECT
    LW.ID_Lowongan,
    LW.ID_Perusahaan,
    LW.Posisi,
    LW.Deskripsi,
    LW.Lokasi,
    P.Nama_Perusahaan
FROM Lowongan LW
JOIN Perusahaan P ON LW.ID_Perusahaan = P.ID_Perusahaan;
GO

-- ──── SP: Register User ────
CREATE OR ALTER PROCEDURE sp_RegisterUser
    @Nama       VARCHAR(100),
    @Email      VARCHAR(100),
    @Password   VARCHAR(255),
    @Jalan      VARCHAR(100),
    @Desa       VARCHAR(100),
    @Kabupaten  VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Nama='' OR @Email='' OR @Password='' OR @Jalan='' OR @Desa='' OR @Kabupaten=''
    BEGIN RAISERROR('Semua kolom harus diisi!', 16, 1); RETURN; END

    IF LEN(@Password) < 8
    BEGIN RAISERROR('Password harus minimal 8 karakter!', 16, 1); RETURN; END

    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN RAISERROR('Email sudah terdaftar!', 16, 1); RETURN; END

    INSERT INTO Users (Nama, Email, Password, Jalan, Desa, Kabupaten)
    VALUES (@Nama, @Email, @Password, @Jalan, @Desa, @Kabupaten);
    PRINT 'User berhasil didaftarkan!';
END
GO

-- ──── SP: Register Perusahaan ────
CREATE OR ALTER PROCEDURE sp_RegisterPerusahaan
    @NamaPT     VARCHAR(100),
    @EmailPT    VARCHAR(100),
    @PasswordPT VARCHAR(255),
    @AlamatPT   VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    IF @NamaPT='' OR @EmailPT='' OR @PasswordPT='' OR @AlamatPT=''
    BEGIN RAISERROR('Semua kolom perusahaan harus diisi!', 16, 1); RETURN; END

    IF LEN(@PasswordPT) < 8
    BEGIN RAISERROR('Password minimal 8 karakter!', 16, 1); RETURN; END

    IF EXISTS (SELECT 1 FROM Perusahaan WHERE Email = @EmailPT)
    BEGIN RAISERROR('Email Perusahaan sudah terdaftar!', 16, 1); RETURN; END

    IF EXISTS (SELECT 1 FROM Perusahaan WHERE Nama_Perusahaan = @NamaPT)
    BEGIN RAISERROR('Nama Perusahaan sudah terdaftar!', 16, 1); RETURN; END

    INSERT INTO Perusahaan (Nama_Perusahaan, Email, Password, Alamat)
    VALUES (@NamaPT, @EmailPT, @PasswordPT, @AlamatPT);
END
GO

-- ──── SP: Insert Lowongan (baru, pakai SP bukan raw INSERT) ────
CREATE OR ALTER PROCEDURE sp_InsertLowongan
    @ID_Perusahaan INT,
    @Posisi        VARCHAR(100),
    @Deskripsi     TEXT,
    @Lokasi        VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    -- Bisnis logik: posisi tidak boleh kosong
    IF LTRIM(RTRIM(@Posisi)) = '' OR @Lokasi = ''
    BEGIN RAISERROR('Posisi dan Lokasi wajib diisi!', 16, 1); RETURN; END

    -- Bisnis logik: cek duplikasi posisi di perusahaan yang sama
    IF EXISTS (SELECT 1 FROM Lowongan WHERE ID_Perusahaan = @ID_Perusahaan AND Posisi = @Posisi)
    BEGIN RAISERROR('Posisi ini sudah ada di perusahaan Anda!', 16, 1); RETURN; END

    INSERT INTO Lowongan (ID_Perusahaan, Posisi, Deskripsi, Lokasi)
    VALUES (@ID_Perusahaan, @Posisi, @Deskripsi, @Lokasi);
END
GO

-- ──── SP: Update Lowongan ────
CREATE OR ALTER PROCEDURE sp_UpdateLowongan
    @ID_Lowongan   INT,
    @ID_Perusahaan INT,
    @Posisi        VARCHAR(100),
    @Deskripsi     TEXT,
    @Lokasi        VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    -- Bisnis logik: pastikan lowongan milik perusahaan yang login
    IF NOT EXISTS (SELECT 1 FROM Lowongan WHERE ID_Lowongan = @ID_Lowongan AND ID_Perusahaan = @ID_Perusahaan)
    BEGIN RAISERROR('Lowongan tidak ditemukan atau bukan milik Anda!', 16, 1); RETURN; END

    -- Bisnis logik: tidak bisa update posisi jika sudah ada lamaran aktif (Pending)
    IF EXISTS (SELECT 1 FROM Lamaran WHERE ID_Lowongan = @ID_Lowongan AND Status = 'Pending')
    BEGIN RAISERROR('Tidak bisa mengubah lowongan yang masih memiliki lamaran Pending!', 16, 1); RETURN; END

    UPDATE Lowongan SET Posisi=@Posisi, Deskripsi=@Deskripsi, Lokasi=@Lokasi
    WHERE ID_Lowongan=@ID_Lowongan AND ID_Perusahaan=@ID_Perusahaan;
END
GO

-- ──── SP: Delete Lowongan ────
CREATE OR ALTER PROCEDURE sp_DeleteLowongan
    @ID_Lowongan   INT,
    @ID_Perusahaan INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Bisnis logik: tidak boleh hapus jika masih ada lamaran
    IF EXISTS (SELECT 1 FROM Lamaran WHERE ID_Lowongan = @ID_Lowongan)
    BEGIN RAISERROR('Tidak bisa menghapus lowongan yang masih memiliki lamaran!', 16, 1); RETURN; END

    -- Bisnis logik: hanya perusahaan pemilik yang bisa hapus
    IF NOT EXISTS (SELECT 1 FROM Lowongan WHERE ID_Lowongan = @ID_Lowongan AND ID_Perusahaan = @ID_Perusahaan)
    BEGIN RAISERROR('Lowongan tidak ditemukan atau bukan milik Anda!', 16, 1); RETURN; END

    DELETE FROM Lowongan WHERE ID_Lowongan=@ID_Lowongan AND ID_Perusahaan=@ID_Perusahaan;
END
GO

-- ──── SP: Search Lowongan ────
CREATE OR ALTER PROCEDURE sp_SearchLowongan
    @Cari VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM vw_LowonganTersedia
    WHERE Posisi LIKE '%' + @Cari + '%'
       OR Nama_Perusahaan LIKE '%' + @Cari + '%'
       OR Lokasi LIKE '%' + @Cari + '%';
END
GO

-- ──── SP: Insert Lamaran ────
CREATE OR ALTER PROCEDURE sp_InsertLamaran
    @ID_User    INT,
    @ID_Lowongan INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Bisnis logik: cek duplikasi
    IF EXISTS (SELECT 1 FROM Lamaran WHERE ID_User=@ID_User AND ID_Lowongan=@ID_Lowongan)
    BEGIN RAISERROR('Anda sudah melamar di lowongan ini!', 16, 1); RETURN; END

    -- Bisnis logik: lowongan harus ada
    IF NOT EXISTS (SELECT 1 FROM Lowongan WHERE ID_Lowongan=@ID_Lowongan)
    BEGIN RAISERROR('Lowongan tidak ditemukan!', 16, 1); RETURN; END

    INSERT INTO Lamaran (ID_User, ID_Lowongan, TanggalLamaran, Status)
    VALUES (@ID_User, @ID_Lowongan, GETDATE(), 'Pending');
END
GO

-- ──── SP: Update Status Lamaran ────
CREATE OR ALTER PROCEDURE sp_UpdateStatusLamaran
    @ID_Lamaran INT,
    @StatusBaru VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @StatusLama VARCHAR(20);
    SELECT @StatusLama = Status FROM Lamaran WHERE ID_Lamaran = @ID_Lamaran;

    IF @StatusLama IS NULL
    BEGIN RAISERROR('Lamaran tidak ditemukan!', 16, 1); RETURN; END

    -- Bisnis logik: status valid hanya Pending/Diterima/Ditolak
    IF @StatusBaru NOT IN ('Pending', 'Diterima', 'Ditolak')
    BEGIN RAISERROR('Status tidak valid! Gunakan: Pending, Diterima, atau Ditolak.', 16, 1); RETURN; END

    -- Bisnis logik: yang sudah diproses tidak bisa kembali ke Pending
    IF @StatusLama IN ('Diterima', 'Ditolak') AND @StatusBaru = 'Pending'
    BEGIN RAISERROR('Lamaran yang sudah diproses tidak bisa dikembalikan ke Pending!', 16, 1); RETURN; END

    UPDATE Lamaran SET Status=@StatusBaru WHERE ID_Lamaran=@ID_Lamaran;
END
GO

-- ──── SP: Delete Lamaran (User batalkan) ────
CREATE OR ALTER PROCEDURE sp_DeleteLamaran
    @ID_Lamaran INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Lamaran WHERE ID_Lamaran=@ID_Lamaran AND Status != 'Pending')
    BEGIN RAISERROR('Tidak bisa menghapus lamaran yang sudah diproses!', 16, 1); RETURN; END

    DELETE FROM Lamaran WHERE ID_Lamaran=@ID_Lamaran;
END
GO

-- ──── SP: Search/Filter User (untuk FormUserCRUD) ────
CREATE OR ALTER PROCEDURE sp_SearchUser
    @Cari VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID_User, Nama, Email, Jalan, Desa, Kabupaten
    FROM Users
    WHERE Nama  LIKE '%' + @Cari + '%'
       OR Email LIKE '%' + @Cari + '%';
END
GO

-- ──── SP: Update User (untuk FormUserCRUD) ────
CREATE OR ALTER PROCEDURE sp_UpdateUser
    @ID_User  INT,
    @Nama     VARCHAR(100),
    @Email    VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Nama = '' OR @Email = ''
    BEGIN RAISERROR('Nama dan Email tidak boleh kosong!', 16, 1); RETURN; END

    -- Bisnis logik: cek email duplikat ke user lain
    IF EXISTS (SELECT 1 FROM Users WHERE Email=@Email AND ID_User != @ID_User)
    BEGIN RAISERROR('Email sudah digunakan oleh user lain!', 16, 1); RETURN; END

    UPDATE Users SET Nama=@Nama, Email=@Email WHERE ID_User=@ID_User;
END
GO

-- ──── SP: Delete User ────
CREATE OR ALTER PROCEDURE sp_DeleteUser
    @ID_User INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Bisnis logik: tidak bisa hapus user yang masih punya lamaran aktif
    IF EXISTS (SELECT 1 FROM Lamaran WHERE ID_User=@ID_User AND Status='Pending')
    BEGIN RAISERROR('Tidak bisa menghapus user yang masih memiliki lamaran Pending!', 16, 1); RETURN; END

    -- Hapus semua lamaran user dulu, baru hapus user
    DELETE FROM Lamaran WHERE ID_User=@ID_User;
    DELETE FROM Users    WHERE ID_User=@ID_User;
END
GO


EXEC sp_RegisterUser 'Andi Pratama',  'andi@gmail.com', 'password123', 'Jl. Malioboro',  'Sosromenduran', 'Yogyakarta';
EXEC sp_RegisterUser 'Budi Santoso',  'budi@gmail.com', 'budipass123', 'Jl. Kaliurang',  'Caturtunggal',  'Sleman';

SELECT * FROM Users;

EXEC sp_RegisterPerusahaan 'PT Maju Jaya',           'majujaya@gmail.com',           'password123', 'Jl. Sudirman No. 10, Jakarta';
EXEC sp_RegisterPerusahaan 'PT Teknologi Nusantara', 'teknologinusantara@gmail.com', 'password123', 'Jl. Merdeka No. 5, Bandung';

SELECT * FROM Perusahaan;

EXEC sp_InsertLowongan 1, 'Frontend Developer', 'Mengembangkan UI menggunakan React', 'Jakarta';
EXEC sp_InsertLowongan 2, 'Backend Developer',  'Mengelola Database SQL',             'Bandung';

SELECT * FROM Lowongan;

EXEC sp_InsertLamaran @ID_User=1, @ID_Lowongan=1;
EXEC sp_InsertLamaran @ID_User=2, @ID_Lowongan=2;

SELECT * FROM Lamaran;

CREATE TABLE LogLamaran
(
    ID_Log INT IDENTITY(1,1) PRIMARY KEY,
    ID_Lamaran INT,
    Aktivitas VARCHAR(100),
    Tanggal DATETIME DEFAULT GETDATE()
)

SELECT * FROM LogLamaran;

CREATE TRIGGER trg_InsertLamaran
ON Lamaran
AFTER INSERT
AS
BEGIN
    INSERT INTO LogLamaran
    (
        ID_Lamaran,
        Aktivitas
    )
    SELECT
        ID_Lamaran, 'User membuat lamaran baru'
    FROM inserted
END

SELECT 
ID_Lowongan,
ID_Perusahaan,
Posisi
FROM Lowongan