using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;


namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{ 
    public class SignInController
    {
        private readonly SignInForm signInForm;
        private readonly ITaiKhoanDAO taiKhoanDAO;
        private SignUpForm signUpForm;
        public SignInController(SignInForm signInForm)
        {
            this.signInForm = signInForm;
            this.taiKhoanDAO = new TaiKhoanDAOImpl();
        }

        public void InitController()
        {
            this.signInForm.LinkSignUp.LinkClicked += new LinkLabelLinkClickedEventHandler(HandleSignUp);
            this.signInForm.ButtonSignIn.Click += new EventHandler(HandleSignIn);
        }

        private void HandleSignIn(object sender, EventArgs e)
        {
            string email = signInForm.TextBoxEmail.Text;
            string pass = signInForm.TextBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!Authenticator.IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Authenticator.IsValidPassword(pass))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (taiKhoanDAO.GetTaiKhoan(email) == null)
            {
                MessageBox.Show("Tài khoản không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!Authenticator.IsValidUser(email, pass))
                {
                    MessageBox.Show("Mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    TaiKhoan tk = taiKhoanDAO.GetTaiKhoan(email);
                    Constant.TaiKhoan = tk;
                    Constant.Role = tk.VaiTro;
                    using (StreamWriter writer = new StreamWriter("D:\\MyProjects\\QuanLyNhaTro_NET\\QuanLyNhaTro_NET\\Resources\\read.txt", true)) // `true` để ghi thêm (append)
                    {
                        writer.WriteLine(Constant.TaiKhoan.MaTaiKhoan);
                        writer.WriteLine(Constant.TaiKhoan.ToString());

                    }
                    MessageBox.Show("Đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (taiKhoanDAO.CheckLogin(email))
                    {
                        signInForm.Hide();
                        SignUpInforForm signUpInforForm = new SignUpInforForm();
                        signUpInforForm.FormClosed += (s, args) => signInForm.Show();
                        signUpInforForm.Show();
                    }
                    else
                    {
                        signInForm.Hide();
                        MenuForm menuForm = new MenuForm();
                        menuForm.Show();
                    }
                }
            }
        }

        private void HandleSignUp(object sender, EventArgs e)
        {
            try
            {
                
                signInForm.Hide();
                if (signUpForm == null || signUpForm.IsDisposed)
                { 
                    signUpForm = new SignUpForm();
                    signUpForm.FormClosed += (s, args) => signInForm.Show();
                }
                signUpForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}