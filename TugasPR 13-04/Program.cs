using System;
using System.Globalization;

// Kelas induk Karyawan
class Karyawan
{
    private string namaKaryawan;
    private string idKaryawan;
    private double gajiPokok;

    public Karyawan(string namaKaryawan, string idKaryawan, double gajiPokok)
    {
        this.namaKaryawan = namaKaryawan;
        this.idKaryawan = idKaryawan;
        this.gajiPokok = gajiPokok;
    }

    public string NamaKaryawan
    {
        get { return namaKaryawan; }
        set { namaKaryawan = value; }
    }

    public string IDKaryawan
    {
        get { return idKaryawan; }
        set { idKaryawan = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }

    public void TampilkanInfo()
    {
        Console.WriteLine();
        Console.WriteLine("============== DATA KARYAWAN ==============");
        Console.WriteLine($"Nama       : {namaKaryawan}");
        Console.WriteLine($"ID         : {idKaryawan}");
        Console.WriteLine($"Gaji Akhir : {HitungGaji():C}");
        Console.WriteLine("===========================================");
    }
}

// Karyawan Tetap
class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public KaryawanTetap(string namaKaryawan, string idKaryawan, double gajiPokok)
        : base(namaKaryawan, idKaryawan, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

// Karyawan Kontrak
class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string namaKaryawan, string idKaryawan, double gajiPokok)
        : base(namaKaryawan, idKaryawan, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

// Karyawan Magang
class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string namaKaryawan, string idKaryawan, double gajiPokok)
        : base(namaKaryawan, idKaryawan, gajiPokok) { }
}

// Program Utama
class Program
{
    static void Main()
    {
        string pilihan;
        while (true)
        {
            Console.WriteLine("Pilih jenis karyawan : \n- Tetap \n- Kontrak \n- Magang");
            Console.Write("Masukkan Pilihan (Tetap/Kontrak/Magang) : ");
            pilihan = Console.ReadLine().Trim().ToLower();

            if (pilihan == "tetap" || pilihan == "kontrak" || pilihan == "magang")
                break;
            else
                Console.WriteLine("Pilihan tidak valid. Silakan masukkan 'Tetap', 'Kontrak', atau 'Magang'.\n");
        }

        string namaKaryawan;
        while (true)
        {
            Console.Write("Masukkan Nama: ");
            namaKaryawan = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(namaKaryawan))
                break;
            else
                Console.WriteLine("Nama tidak boleh kosong.\n");
        }

        string idKaryawan;
        while (true)
        {
            Console.Write("Masukkan ID: ");
            idKaryawan = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(idKaryawan))
                break;
            else
                Console.WriteLine("ID tidak boleh kosong.\n");
        }

        double gajiPokok;
        while (true)
        {
            Console.Write("Masukkan Gaji Pokok: ");
            string inputGaji = Console.ReadLine().Trim();
            if (double.TryParse(inputGaji, out gajiPokok) && gajiPokok > 0)
                break;
            else
                Console.WriteLine("Gaji Pokok harus berupa angka dan lebih dari 0.\n");
        }

        Karyawan karyawan;

        switch (pilihan)
        {
            case "tetap":
                karyawan = new KaryawanTetap(namaKaryawan, idKaryawan, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(namaKaryawan, idKaryawan, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(namaKaryawan, idKaryawan, gajiPokok);
                break;
            default:
                // tidak akan terjadi karena sudah divalidasi
                Console.WriteLine("Terjadi kesalahan.");
                return;
        }

        karyawan.TampilkanInfo();
    }
}
