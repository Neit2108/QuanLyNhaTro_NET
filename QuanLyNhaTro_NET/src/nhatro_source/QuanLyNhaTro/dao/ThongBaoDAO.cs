using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IThongBaoDAO
    {
        void AddThongBao(int maNguoiGui, int maNguoiNhan, string noiDung, string trangThai, int maPhong, string loaiThongBao);
        List<ThongBao> GetAllThongBao(int maNguoiNhan);
        void UpdateTrangThaiThongBao(int id);
        ThongBao GetThongBao(int maThongBao);
        void DeleteThongBao(int maThongBao);
        void DeleteAllThongBao(int maNguoiNhan);
    }
}