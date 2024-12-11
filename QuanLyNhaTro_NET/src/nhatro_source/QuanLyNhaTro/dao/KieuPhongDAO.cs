using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IKieuPhongDAO
    {
        void AddKieuPhong(string loaiPhong, double dienTich, double giaPhong);
        void UpdateKieuPhong(int maKieuPhong, string loaiPhong, double dienTich, double giaPhong);
        void DeleteKieuPhong(int maKieuPhong);
        KieuPhong GetKieuPhong(int maKieuPhong);
        List<KieuPhong> GetAllKieuPhong();
    }
}