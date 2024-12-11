namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class DichVu
    {
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public double GiaDichVu { get; set; }
        public string TrangThai { get; set; }

        public DichVu() { }

        public DichVu(int maDichVu, string tenDichVu, double giaDichVu, string trangThai)
        {
            MaDichVu = maDichVu;
            TenDichVu = tenDichVu;
            GiaDichVu = giaDichVu;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"DichVu{{ maDichVu='{MaDichVu}', tenDichVu='{TenDichVu}', giaDichVu='{GiaDichVu}', trangThai='{TrangThai}' }}";
        }
    }
}