using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IChuNhaDAO
    {
        void AddChuNha(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan);
        ChuNha GetChuNhaByMa(int maChuNha);
        ChuNha GetChuNhaByCCCD(string maCCCD);
        List<ChuNha> GetAllChuNha();
        void UpdateChuNha(string maCCCD, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int maTaiKhoan);
    }
}