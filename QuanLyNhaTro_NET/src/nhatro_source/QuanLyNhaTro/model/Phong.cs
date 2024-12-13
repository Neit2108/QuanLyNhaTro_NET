namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class Phong
    {
        private int maPhong;
        private string tenPhong;
        private int maKieuPhong;
        private int maNhaTro;
        private string trangThai;
        private string urlImage;

        public int MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }

        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }

        public int MaKieuPhong
        {
            get { return maKieuPhong; }
            set { maKieuPhong = value; }
        }

        public int MaNhaTro
        {
            get { return maNhaTro; }
            set { maNhaTro = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public string UrlImage
        {
            get { return urlImage; }
            set { urlImage = value; }
        }


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