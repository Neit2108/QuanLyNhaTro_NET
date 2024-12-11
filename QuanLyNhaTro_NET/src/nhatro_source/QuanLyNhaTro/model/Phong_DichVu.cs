namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class PhongDichVu
    {
        public int MaPhong { get; set; }
        public int MaDichVu { get; set; }
        public string GhiChu { get; set; }

        public PhongDichVu() { }

        public PhongDichVu(int maPhong, int maDichVu, string ghiChu)
        {
            MaPhong = maPhong;
            MaDichVu = maDichVu;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"PhongDichVu{{ maPhong='{MaPhong}', maDichVu='{MaDichVu}', ghiChu='{GhiChu}' }}";
        }
    }
}