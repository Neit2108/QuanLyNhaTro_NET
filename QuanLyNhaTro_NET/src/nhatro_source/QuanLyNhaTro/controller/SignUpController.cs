using System;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class SignUpController
    {
        private readonly SignUpForm signUpForm;
        private readonly SignUpCode signUpCode;
        private readonly ITaiKhoanDAO taiKhoanDAO;
        private readonly EmailVerification emailVerification;
        private string verifyCode;

        public SignUpController(SignUpForm signUpForm, SignUpCode signUpCode)
        {
            this.signUpForm = signUpForm;
            this.signUpCode = signUpCode;
            this.taiKhoanDAO = new TaiKhoanDAOImpl();
            this.emailVerification = new EmailVerification();
            this.verifyCode = "";
        }

        public void InitController()
        {
            this.signUpForm.ButtonSignUp.Click += HandleSignUp;
            this.signUpCode.buttonOK.Click += HandleGetCode;
            this.signUpForm.LinkSignIn.Click += HandleSignIn;
        }

        private void HandleSignUp(object sender, EventArgs e)
        {
            string email = signUpForm.TextBoxEmail.Text;
            string password = signUpForm.TextBoxPassword.Text;
            string confirmPassword = signUpForm.TextBoxConfirmPassword.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
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
                if (!Authenticator.IsValidPassword(password))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Mật khẩu không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (taiKhoanDAO.GetTaiKhoan(email) != null)
            {
                MessageBox.Show("Email đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            verifyCode = emailVerification.SendVerificationEmail(email);
            this.signUpCode.Visible = true;
        }

        private void HandleGetCode(object sender, EventArgs e)
        {
            string email = signUpForm.TextBoxEmail.Text;
            string password = signUpForm.TextBoxPassword.Text;
            string confirmPass = signUpForm.TextBoxConfirmPassword.Text;
            string code = signUpCode.textBoxCode.Text;
            if (code.Equals(verifyCode))
            {
                try
                {
                    taiKhoanDAO.AddTaiKhoan(email, password, "Khách Thuê");
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    signUpCode.Dispose();
                    signUpForm.Dispose();
                    var signInForm = new SignInForm();
                    signInForm.Show();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Đăng ký thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSignIn(object sender, EventArgs e)
        {
            try
            {
                signUpForm.Hide();
                var signInForm = new SignInForm();
                signInForm.FormClosed += (s, args) => signUpForm.Show();
                signInForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}