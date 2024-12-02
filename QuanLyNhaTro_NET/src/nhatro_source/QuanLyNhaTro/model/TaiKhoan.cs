using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model
{
    public class TaiKhoan
    {
        // Private fields
        private int _maTaiKhoan;
        private string _email;
        private string _password;
        private string _vaiTro;
        private DateTime _ngayTao;

        // Properties with manual getter/setter
        public int MaTaiKhoan
        {
            get { return _maTaiKhoan; }
            set { _maTaiKhoan = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string VaiTro
        {
            get { return _vaiTro; }
            set { _vaiTro = value; }
        }

        public DateTime NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
        }

        // Constructor
        public TaiKhoan(int maTaiKhoan, string email, string password, string vaiTro, DateTime ngayTao)
        {
            _maTaiKhoan = maTaiKhoan;
            _email = email;
            _password = password;
            _vaiTro = vaiTro;
            _ngayTao = ngayTao;
        }

        // Default constructor
        public TaiKhoan()
        {
        }

        // Override ToString method
        public override string ToString()
        {
            return $"TaiKhoan{{" +
                   $"maTaiKhoan='{_maTaiKhoan}', " +
                   $"email='{_email}', " +
                   $"password='{_password}', " +
                   $"vaiTro='{_vaiTro}', " +
                   $"ngayTao='{_ngayTao}'" +
                   $"}}";
        }
    }
}
