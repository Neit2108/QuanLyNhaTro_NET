using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface IPhong_DichVu_DAO
    {
        List<DichVu> GetAllDichVuPhong(int maPhong);
        List<string> GetAllTrangThaiPhong(int maPhong);
    }
}