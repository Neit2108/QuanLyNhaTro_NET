using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaHopDong { get; set; }
        public double TongTien { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string TrangThai { get; set; }

        public HoaDon() { }

        public HoaDon(int maHoaDon, int maHopDong, double tongTien, DateTime ngayTao, DateTime ngayThanhToan, string trangThai)
        {
            MaHoaDon = maHoaDon;
            MaHopDong = maHopDong;
            TongTien = tongTien;
            NgayTao = ngayTao;
            NgayThanhToan = ngayThanhToan;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"HoaDon{{ maHoaDon={MaHoaDon}, maHopDong={MaHopDong}, tongTien={TongTien}, ngayTao={NgayTao}, ngayThanhToan={NgayThanhToan}, trangThai='{TrangThai}' }}";
        }
    }
}