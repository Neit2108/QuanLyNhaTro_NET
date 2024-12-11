using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface INhaTroDAO
    {
        List<NhaTro> GetAllNhaTroByMaChuNha(int maChuNha);
        List<NhaTro> GetAllNhaTro();
        void AddNhaTro(int maChuNha, string diaChi, int soLuongPhong, string trangThai, string urlImage);
        void UpdateNhaTro(int maNhaTro, int maChuNha, string diaChi, int soLuongPhong, string trangThai, string urlImage);
        void DeleteNhaTro(int maNhaTro);
        NhaTro GetNhaTroByMaNhaTro(int maNhaTro);
    }
}