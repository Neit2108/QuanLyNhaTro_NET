using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface ITienThuDAO
    {
        List<TienThuTienIch> GetAll();
        TienThuTienIch GetTienThu(int maTienThu);
    }
}