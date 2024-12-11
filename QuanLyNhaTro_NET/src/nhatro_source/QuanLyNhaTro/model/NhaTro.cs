namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class NhaTro
    {
        public int MaNhaTro { get; set; }
        public int MaChuNha { get; set; }
        public string DiaChi { get; set; }
        public int SoLuongPhong { get; set; }
        public string TrangThai { get; set; }
        public string UrlImage { get; set; }

        public NhaTro() { }

        public NhaTro(int maNhaTro, int maChuNha, string diaChi, int soLuongPhong, string trangThai, string urlImage)
        {
            MaNhaTro = maNhaTro;
            MaChuNha = maChuNha;
            DiaChi = diaChi;
            SoLuongPhong = soLuongPhong;
            TrangThai = trangThai;
            UrlImage = urlImage;
        }

        public override string ToString()
        {
            return $"NhaTro{{ maNhaTro='{MaNhaTro}', maChuNha='{MaChuNha}', diaChi='{DiaChi}', soLuongPhong='{SoLuongPhong}', trangThai='{TrangThai}', urlImage='{UrlImage}' }}";
        }
    }
}