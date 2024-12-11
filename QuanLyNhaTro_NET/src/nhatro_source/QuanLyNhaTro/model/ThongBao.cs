using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class ThongBao
    {
        public int Id { get; set; }
        public int MaNguoiGui { get; set; }
        public int MaNguoiNhan { get; set; }
        public int MaPhong { get; set; }
        public string NoiDung { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public string LoaiThongBao { get; set; }

        public override string ToString()
        {
            return $"ThongBao{{ id={Id}, maNguoiGui={MaNguoiGui}, maNguoiNhan={MaNguoiNhan}, maPhong={MaPhong}, noiDung='{NoiDung}', trangThai='{TrangThai}', ngayTao={NgayTao}, loaiThongBao='{LoaiThongBao}' }}";
        }
    }
}