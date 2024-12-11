using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class ThanhToan
    {
        public int MaThanhToan { get; set; }
        public int MaHoaDon { get; set; }
        public double SoTien { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayThanhToan { get; set; }

        public ThanhToan() { }

        public ThanhToan(int maThanhToan, int maHoaDon, double soTien, string trangThai, DateTime ngayThanhToan)
        {
            MaThanhToan = maThanhToan;
            MaHoaDon = maHoaDon;
            SoTien = soTien;
            TrangThai = trangThai;
            NgayThanhToan = ngayThanhToan;
        }

        public override string ToString()
        {
            return $"ThanhToan{{ maThanhToan={MaThanhToan}, maHoaDon={MaHoaDon}, soTien={SoTien}, trangThai='{TrangThai}', ngayThanhToan={NgayThanhToan} }}";
        }
    }
}