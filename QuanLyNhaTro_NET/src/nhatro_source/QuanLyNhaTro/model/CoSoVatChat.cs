namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class CoSoVatChat
    {
        public int MaCSVC { get; set; }
        public string TenCSVC { get; set; }
        public string TrangThai { get; set; }

        public CoSoVatChat() { }

        public CoSoVatChat(int maCSVC, string tenCSVC, string trangThai)
        {
            MaCSVC = maCSVC;
            TenCSVC = tenCSVC;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"CoSoVatChat{{ maCSVC='{MaCSVC}', tenCSVC='{TenCSVC}', trangThai='{TrangThai}' }}";
        }
    }
}