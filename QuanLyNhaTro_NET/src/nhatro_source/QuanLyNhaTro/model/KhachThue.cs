using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class KhachThue : Person
    {
        public int MaKhach { get; set; }
        public int MaTaiKhoan { get; set; }

        public KhachThue() { }

        public KhachThue(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maKhach, int maTaiKhoan)
            : base(maCCCD, ten, ngaySinh, gioiTinh, soDienThoai, diaChi)
        {
            MaKhach = maKhach;
            MaTaiKhoan = maTaiKhoan;
        }

        public override string ToString()
        {
            return $"KhachThue{{ maCCCD='{MaCCCD}', ten='{Ten}', ngaySinh='{NgaySinh}', gioiTinh='{GioiTinh}', soDienThoai='{SoDienThoai}', diaChi='{DiaChi}', maKhach={MaKhach}, maTaiKhoan={MaTaiKhoan} }}";
        }
    }
}