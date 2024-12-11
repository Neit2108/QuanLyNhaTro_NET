namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class Phong
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public int MaKieuPhong { get; set; }
        public int MaNhaTro { get; set; }
        public string TrangThai { get; set; }
        public string UrlImage { get; set; }

        public Phong() { }

        public Phong(int maPhong, string tenPhong, int maKieuPhong, int maNhaTro, string trangThai, string urlImage)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            MaKieuPhong = maKieuPhong;
            MaNhaTro = maNhaTro;
            TrangThai = trangThai;
            UrlImage = urlImage;
        }

        public override string ToString()
        {
            return $"Phong{{ maPhong='{MaPhong}', tenPhong='{TenPhong}', maKieuPhong={MaKieuPhong}, maNhaTro={MaNhaTro}, trangThai='{TrangThai}', urlImage='{UrlImage}' }}";
        }
    }
}