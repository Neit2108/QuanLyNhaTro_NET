using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class Admin : Person
    {
        public int MaAdmin { get; set; }
        public int MaTaiKhoan { get; set; }

        public Admin() { }

        public Admin(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maAdmin, int maTaiKhoan)
            : base(maCCCD, ten, ngaySinh, gioiTinh, soDienThoai, diaChi)
        {
            MaAdmin = maAdmin;
            MaTaiKhoan = maTaiKhoan;
        }

        public override string ToString()
        {
            return $"Admin{{ maCCCD='{MaCCCD}', ten='{Ten}', ngaySinh='{NgaySinh}', gioiTinh='{GioiTinh}', soDienThoai='{SoDienThoai}', diaChi='{DiaChi}', maAdmin={MaAdmin}, maTaiKhoan={MaTaiKhoan} }}";
        }
    }
}