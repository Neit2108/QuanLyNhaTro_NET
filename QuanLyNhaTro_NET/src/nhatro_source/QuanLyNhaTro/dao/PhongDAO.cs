using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IPhongDAO
    {
        void AddPhong(string tenPhong, int maKieuPhong, int maNhaTro, string urlImage);
        void UpdatePhong(int maPhong, string tenPhong, int maKieuPhong, int maNhaTro, string urlImage);
        void DeletePhong(int maPhong);
        Phong GetPhong(int maPhong);
        List<Phong> GetAllPhong();
        List<Phong> GetAllPhongByMaNhaTro(int maNhaTro);
        double GetGiaPhong(int maPhong);
        int GetMaChuNha(int maPhong);
        void UpdateTrangThaiPhong(int maPhong, string trangThai);
        List<Phong> GetAllPhongByMaKhach(int maKhach);
        void UpdateTrangThaiPhong(int maPhong);
    }
}