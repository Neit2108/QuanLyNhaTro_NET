using System;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public abstract class Person
    {
        public string MaCCCD { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        protected Person() { }

        protected Person(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi)
        {
            MaCCCD = maCCCD;
            Ten = ten;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
    }
}