using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class AccountInfoController
    {
        private readonly AccountInforForm accountInforForm;
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();


        public AccountInfoController(AccountInforForm accountInforForm)
        {
            this.accountInforForm = accountInforForm;
        }

        public void Init()
        {
            HandleInfo();
            accountInforForm.AddressTextBox.ReadOnly = true;
            accountInforForm.BirthDatePicker.Enabled = false;
            accountInforForm.CccdTextBox.ReadOnly = true;
            accountInforForm.EmailTextBox.ReadOnly = true;
            accountInforForm.GenderComboBox.Enabled = false;
            accountInforForm.PhoneTextBox.ReadOnly = true;
            accountInforForm.NameTextBox.ReadOnly = true;

            accountInforForm.SaveButton.Enabled = false;
            accountInforForm.EditButton.Click += HandleEditButton;
            accountInforForm.SaveButton.Click += HandleSaveButton;
        }

        private void HandleEditButton(object sender, EventArgs e)
        {
            accountInforForm.AddressTextBox.ReadOnly = false;
            accountInforForm.BirthDatePicker.Enabled = true;
            accountInforForm.CccdTextBox.ReadOnly = false;
            accountInforForm.EmailTextBox.ReadOnly = false;
            accountInforForm.GenderComboBox.Enabled = true;
            accountInforForm.PhoneTextBox.ReadOnly = false;
            accountInforForm.NameTextBox.ReadOnly = false;

            accountInforForm.SaveButton.Enabled = true;
        }

        private void HandleSaveButton(object sender, EventArgs e)
        {
            string email = accountInforForm.EmailTextBox.Text;
            string phone = accountInforForm.PhoneTextBox.Text;
            string address = accountInforForm.AddressTextBox.Text;
            string name = accountInforForm.NameTextBox.Text;
            string birth = accountInforForm.BirthDatePicker.Value.ToString("yyyy-MM-dd");
            string cccd = accountInforForm.CccdTextBox.Text;
            string gender = accountInforForm.GenderComboBox.SelectedItem.ToString();

            ITaiKhoanDAO taiKhoanDAO = new TaiKhoanDAOImpl();
            int maTaiKhoan = Constant.TaiKhoan.MaTaiKhoan;

            if (Constant.Role.Equals("Khách Thuê", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaKhachThue(maTaiKhoan);
                new KhachThueDAOImpl().UpdateKhachThueByMa(id, cccd, name, DateTime.Parse(birth), gender, phone, address, maTaiKhoan);
            }
            else if (Constant.Role.Equals("Chủ Nhà", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaChuNha(maTaiKhoan);
                new ChuNhaDAOImpl().UpdateChuNhaByMa(id, cccd, name, DateTime.Parse(birth), gender, phone, address, maTaiKhoan);
            }
            else if (Constant.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaAdmin(maTaiKhoan);
                new AdminDAOImpl().UpdateAdmin(cccd, name, DateTime.Parse(birth), gender, phone, address, id, maTaiKhoan);
            }

            accountInforForm.AddressTextBox.ReadOnly = true;
            accountInforForm.BirthDatePicker.Enabled = false;
            accountInforForm.CccdTextBox.ReadOnly = true;
            accountInforForm.EmailTextBox.ReadOnly = true;
            accountInforForm.GenderComboBox.Enabled = false;
            accountInforForm.PhoneTextBox.ReadOnly = true;
            accountInforForm.NameTextBox.ReadOnly = true;

            MessageBox.Show(accountInforForm, "Cập nhật thông tin thành công");
            accountInforForm.SaveButton.Enabled = false;
        }

        private void HandleInfo()
        {
            ITaiKhoanDAO taiKhoanDAO = new TaiKhoanDAOImpl();
            int maTaiKhoan = Constant.TaiKhoan.MaTaiKhoan;
            if (Constant.Role.Equals("Khách Thuê", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaKhachThue(maTaiKhoan);
                
                KhachThue khachThue = new KhachThueDAOImpl().GetKhachThue(id);
                using (StreamWriter writer = new StreamWriter("D:\\MyProjects\\QuanLyNhaTro_NET\\QuanLyNhaTro_NET\\Resources\\read.txt", true)) // `true` để ghi thêm (append)
                {
                    writer.WriteLine("Mã khách : " + id);
                    writer.WriteLine(khachThue.ToString());

                }
                accountInforForm.NameLabel.Text = khachThue.Ten;
                accountInforForm.NameTextBox.Text = khachThue.Ten;
                accountInforForm.EmailTextBox.Text = Constant.TaiKhoan.Email;
                accountInforForm.PhoneTextBox.Text = khachThue.SoDienThoai;
                accountInforForm.AddressTextBox.Text = khachThue.DiaChi;
                accountInforForm.GenderComboBox.SelectedItem = khachThue.GioiTinh;
                DateTime ngaySinh = khachThue.NgaySinh;
                accountInforForm.BirthDatePicker.Value = ngaySinh;
                accountInforForm.CccdTextBox.Text = khachThue.MaCCCD;
            }
            else if (Constant.Role.Equals("Chủ Nhà", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaChuNha(maTaiKhoan);
                ChuNha chuNha = new ChuNhaDAOImpl().GetChuNhaByMa(id);
                accountInforForm.NameLabel.Text = chuNha.Ten;
                accountInforForm.NameTextBox.Text = chuNha.Ten;
                accountInforForm.EmailTextBox.Text = Constant.TaiKhoan.Email;
                accountInforForm.PhoneTextBox.Text = chuNha.SoDienThoai;
                accountInforForm.AddressTextBox.Text = chuNha.DiaChi;
                accountInforForm.GenderComboBox.SelectedItem = chuNha.GioiTinh;
                accountInforForm.BirthDatePicker.Value = chuNha.NgaySinh;
                accountInforForm.CccdTextBox.Text = chuNha.MaCCCD;
            }
            else if (Constant.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                int id = taiKhoanDAO.GetMaAdmin(maTaiKhoan);
                Admin admin = new AdminDAOImpl().GetAdminByMa(id);
                accountInforForm.NameLabel.Text = admin.Ten;
                accountInforForm.NameTextBox.Text = admin.Ten;
                accountInforForm.EmailTextBox.Text = Constant.TaiKhoan.Email;
                accountInforForm.PhoneTextBox.Text = admin.SoDienThoai;
                accountInforForm.AddressTextBox.Text = admin.DiaChi;
                accountInforForm.GenderComboBox.SelectedItem = admin.GioiTinh;
                accountInforForm.BirthDatePicker.Value = admin.NgaySinh;
                accountInforForm.CccdTextBox.Text = admin.MaCCCD;
            }
        }
    }
}