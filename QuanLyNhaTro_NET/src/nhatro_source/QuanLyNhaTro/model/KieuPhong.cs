using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class KieuPhong
    {
        public int MaKieuPhong { get; set; }
        public string LoaiPhong { get; set; }
        public double DienTich { get; set; }
        public double GiaPhong { get; set; }
        public DateTime NgayTao { get; set; }

        public KieuPhong() { }

        public KieuPhong(int maKieuPhong, string loaiPhong, double dienTich, double giaPhong, DateTime ngayTao)
        {
            MaKieuPhong = maKieuPhong;
            LoaiPhong = loaiPhong;
            DienTich = dienTich;
            GiaPhong = giaPhong;
            NgayTao = ngayTao;
        }

        public override string ToString()
        {
            return $"KieuPhong{{ maKieuPhong='{MaKieuPhong}', loaiPhong='{LoaiPhong}', dienTich={DienTich}, giaPhong={GiaPhong}, ngayTao={NgayTao} }}";
        }
    }
}