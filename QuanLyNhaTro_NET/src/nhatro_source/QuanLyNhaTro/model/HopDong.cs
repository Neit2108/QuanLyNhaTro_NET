using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class HopDong
    {
        public int MaHopDong { get; set; }
        public int MaPhong { get; set; }
        public int MaKhachThue { get; set; }
        public double TienCoc { get; set; }
        public int SoNguoi { get; set; }
        public DateTime NgayThue { get; set; }
        public int ThoiHanHopDong { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }

        public HopDong() { }

        public HopDong(int maHopDong, int maPhong, int maKhachThue, double tienCoc, int soNguoi, DateTime ngayThue, int thoiHanHopDong, DateTime ngayTao, string trangThai)
        {
            MaHopDong = maHopDong;
            MaPhong = maPhong;
            MaKhachThue = maKhachThue;
            TienCoc = tienCoc;
            SoNguoi = soNguoi;
            NgayThue = ngayThue;
            ThoiHanHopDong = thoiHanHopDong;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"HopDong{{ maHopDong={MaHopDong}, maPhong={MaPhong}, maKhachThue={MaKhachThue}, tienCoc={TienCoc}, soNguoi={SoNguoi}, ngayThue={NgayThue}, thoiHanHopDong={ThoiHanHopDong}, ngayTao={NgayTao}, trangThai='{TrangThai}' }}";
        }
    }
}