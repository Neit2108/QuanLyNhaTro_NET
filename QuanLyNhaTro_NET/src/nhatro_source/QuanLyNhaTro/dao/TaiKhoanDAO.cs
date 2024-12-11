using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface ITaiKhoanDAO
    {
        void AddTaiKhoan(string email, string password, string vaiTro);
        List<TaiKhoan> GetAllTaiKhoan();
        TaiKhoan GetTaiKhoan(int maTaiKhoan);
        TaiKhoan GetTaiKhoan(string email);
        void UpdateTaiKhoan(string email, string vaiTro);
        void DeleteTaiKhoan(string email);
        int GetMaChuNha(int maTaiKhoan);
        int GetMaKhachThue(int maTaiKhoan);
        int GetMaAdmin(int maTaiKhoan);
        bool CheckLogin(string email);
        void UpdateLogin(string email);
    }
}