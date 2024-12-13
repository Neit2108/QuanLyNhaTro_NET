using System;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class SignUpInforController
    {
        private readonly SignUpInforForm signUpInforForm;

        public SignUpInforController(SignUpInforForm signUpInforForm)
        {
            this.signUpInforForm = signUpInforForm;
        }

        public void Init()
        {
            signUpInforForm.SubmitButton.Click += (sender, e) => HandleSubmitBtn();
        }

        private void HandleSubmitBtn()
        {
            string cccd = signUpInforForm.CccdTextBox.Text;
            string name = signUpInforForm.NameTextBox.Text;
            string birthday = signUpInforForm.BirthdayTextBox.Text;
            birthday = Authenticator.NormalizeDate(birthday);
            string gender = signUpInforForm.GenderComboBox.Text;
            string phoneNumber = signUpInforForm.PhoneNumberTextBox.Text;
            string address = signUpInforForm.AddressTextBox.Text;

            if (string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Constant.Role.Equals("Chủ Nhà", StringComparison.OrdinalIgnoreCase))
            {
                IChuNhaDAO chuNhaDAO = new ChuNhaDAOImpl();
                chuNhaDAO.AddChuNha(cccd, name, DateTime.Parse(birthday), gender, phoneNumber, address, Constant.TaiKhoan.MaTaiKhoan);
            }
            if (Constant.Role.Equals("Khách Thuê", StringComparison.OrdinalIgnoreCase))
            {
                IKhachThueDAO khachThueDAO = new KhachThueDAOImpl();
                khachThueDAO.AddKhachThue(cccd, name, DateTime.Parse(birthday), gender, phoneNumber, address, Constant.TaiKhoan.MaTaiKhoan);
            }

            new TaiKhoanDAOImpl().UpdateLogin(Constant.TaiKhoan.Email);
            MessageBox.Show("Thông tin đã được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            signUpInforForm.Dispose();
            new MenuForm().Show();
        }
    }
}