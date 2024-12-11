namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IThanhToanDAO
    {
        void AddThanhToan(int maHoaDon, double soTien, string hinhThuc, string trangThai);
    }
}