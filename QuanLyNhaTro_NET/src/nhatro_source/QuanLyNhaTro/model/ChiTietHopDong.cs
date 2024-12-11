namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class ChiTietHopDong
    {
        public int MaChiTiet { get; set; }
        public int MaHopDong { get; set; }
        public int MaDichVu { get; set; }
        public int MaCSVC { get; set; }
        public string GhiChu { get; set; }

        public ChiTietHopDong() { }

        public ChiTietHopDong(int maChiTiet, int maHopDong, int maDichVu, int maCSVC, string ghiChu)
        {
            MaChiTiet = maChiTiet;
            MaHopDong = maHopDong;
            MaDichVu = maDichVu;
            MaCSVC = maCSVC;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"ChiTietHopDong{{ maChiTiet={MaChiTiet}, maHopDong={MaHopDong}, maDichVu={MaDichVu}, maCSVC={MaCSVC}, ghiChu='{GhiChu}' }}";
        }
    }
}