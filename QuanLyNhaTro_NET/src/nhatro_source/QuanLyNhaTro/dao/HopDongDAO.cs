using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IHopDongDAO
    {
        void AddHopDong(int maPhong, int maKhachThue, double tienCoc, DateTime ngayThue, int thoiHanHopDong, string trangThai, int soNguoi);
        HopDong GetHopDong(int maHopDong);
        List<HopDong> GetAllHopDong();
        List<HopDong> GetHopDongByMaKhach(int maKhach);
        List<HopDong> GetHopDongByMaChuNha(int maChuNha);
    }
}