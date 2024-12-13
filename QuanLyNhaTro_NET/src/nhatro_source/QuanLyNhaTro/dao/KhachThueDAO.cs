using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IKhachThueDAO
    {
        List<KhachThue> GetAllKhachThue();
        KhachThue GetKhachThue(string maCCCD);
        KhachThue GetKhachThue(int maTaiKhoan);
        void AddKhachThue(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan);
        void UpdateKhachThue(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan);
        void DeleteKhachThue(string maCCCD);
        List<KhachThue> GetKhachThueByMaChuNha(int maChuNha);
        void UpdateKhachThueByMa(int maKhachThue, String maCCCD, String ten, DateTime ngaySinh, String gioiTinh, String soDienThoai, String diaChi, int maTaiKhoan);
    }
}