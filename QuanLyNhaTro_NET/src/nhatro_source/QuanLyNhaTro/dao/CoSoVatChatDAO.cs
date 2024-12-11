using System;
using System.Collections.Generic;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao
{
    public interface ICoSoVatChatDAO
    {
        CoSoVatChat GetCoSoVatChat(int maCoSoVatChat);
        List<CoSoVatChat> GetAllCoSoVatChat(int maPhong);
    }
}