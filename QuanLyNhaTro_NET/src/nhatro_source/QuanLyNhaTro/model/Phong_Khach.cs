namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class PhongKhach
    {
        public int MaPhong { get; set; }
        public int MaKhach { get; set; }
        public string GhiChu { get; set; }

        public PhongKhach() { }

        public PhongKhach(int maPhong, int maKhach, string ghiChu)
        {
            MaPhong = maPhong;
            MaKhach = maKhach;
            GhiChu = ghiChu;
        }

        public override string ToString()
        {
            return $"PhongKhach{{ maPhong='{MaPhong}', maKhach='{MaKhach}', ghiChu='{GhiChu}' }}";
        }
    }
}