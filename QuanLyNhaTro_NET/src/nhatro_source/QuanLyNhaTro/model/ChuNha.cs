using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class ChuNha : Person
    {
        public int MaChuNha { get; set; }
        public int MaTaiKhoan { get; set; }

        public ChuNha() { }

        public ChuNha(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maChuNha, int maTaiKhoan)
            : base(maCCCD, ten, ngaySinh, gioiTinh, soDienThoai, diaChi)
        {
            MaChuNha = maChuNha;
            MaTaiKhoan = maTaiKhoan;
        }

        public override string ToString()
        {
            return $"ChuNha{{ maCCCD='{MaCCCD}', ten='{Ten}', ngaySinh='{NgaySinh}', gioiTinh='{GioiTinh}', soDienThoai='{SoDienThoai}', diaChi='{DiaChi}', maChuNha={MaChuNha}, maTaiKhoan={MaTaiKhoan} }}";
        }
    }
}