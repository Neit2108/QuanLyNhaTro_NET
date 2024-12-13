using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IAdminDAO
    {
        void AddAdmin(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan);
        List<Admin> GetAllAdmins();
        Admin GetAdmin(string maCCCD);
        void UpdateAdmin(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maAdmin, int maTaiKhoan);
        void DeleteAdmin(string maCCCD);
        Admin GetAdminByMa(int maAdmin);
    }
}