using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IDichVuDAO
    {
        void AddDichVu(int maDichVu, string tenDichVu, string trangThai);
        void UpdateDichVu(int maDichVu, string tenDichVu, string trangThai);
        void DeleteDichVu(int maDichVu);
        DichVu GetDichVu(int maDichVu);
        List<DichVu> GetAllDichVu();
    }
}