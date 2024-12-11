using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IHoaDonDAO
    {
        List<HoaDon> GetAllHoaDon();
        List<HoaDon> GetHoaDonByMaKhach(int maKhach);
        List<HoaDon> GetHoaDonByMaNhaTro(int maNhaTro);
        bool IsCreatedHoaDon(DateTime date);
        void AutoCreateHoaDon(int maChuNha, DateTime date);
        void DeleteHoaDon(int maHoaDon);
    }
}