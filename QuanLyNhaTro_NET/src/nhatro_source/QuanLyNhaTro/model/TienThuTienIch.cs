using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class TienThuTienIch
    {
        public int MaTienThu { get; set; }
        public int MaPhong { get; set; }
        public DateTime NgayThu { get; set; }
        public double SoDienCu { get; set; }
        public double SoDienMoi { get; set; }
        public double SoNuocCu { get; set; }
        public double SoNuocMoi { get; set; }
        public double SoDienDaDung { get; set; }
        public double SoNuocDaDung { get; set; }

        public TienThuTienIch() { }

        public TienThuTienIch(int maTienThu, int maPhong, DateTime ngayThu, double soDienCu, double soDienMoi, double soNuocCu, double soNuocMoi, double soDienDaDung, double soNuocDaDung)
        {
            MaTienThu = maTienThu;
            MaPhong = maPhong;
            NgayThu = ngayThu;
            SoDienCu = soDienCu;
            SoDienMoi = soDienMoi;
            SoNuocCu = soNuocCu;
            SoNuocMoi = soNuocMoi;
            SoDienDaDung = soDienDaDung;
            SoNuocDaDung = soNuocDaDung;
        }

        public override string ToString()
        {
            return $"TienThuTienIch{{ maTienThu={MaTienThu}, maPhong={MaPhong}, ngayThu={NgayThu}, soDienCu={SoDienCu}, soDienMoi={SoDienMoi}, soNuocCu={SoNuocCu}, soNuocMoi={SoNuocMoi}, soDienDaDung={SoDienDaDung}, soNuocDaDung={SoNuocDaDung} }}";
        }
    }
}