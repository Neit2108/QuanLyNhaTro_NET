namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class KieuPhongCoSoVatChat
    {
        public int MaKieuPhong { get; set; }
        public int MaCSVC { get; set; }
        public string GhiChu { get; set; }

        public KieuPhongCoSoVatChat() { }

        public KieuPhongCoSoVatChat(int maKieuPhong, int maCSVC, string ghiChu)
        {
            MaKieuPhong = maKieuPhong;
            MaCSVC = maCSVC;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"KieuPhongCoSoVatChat{{ maKieuPhong='{MaKieuPhong}', maCSVC='{MaCSVC}', ghiChu='{GhiChu}' }}";
        }
    }
}