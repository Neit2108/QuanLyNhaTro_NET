using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class SignInForm : Form
    {
        private Panel signInPnl;
        private Panel rightPnl;
        private Panel txtPnl;
        private Panel bottomPnl;
        private TextBox emailField;
        private TextBox passField;
        private Button signInBtn;
        private Button signUpBtn;

        public SignInForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form
            this.Text = "Đăng Nhập";
            this.Size = new Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // signInPnl
            signInPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            this.Controls.Add(signInPnl);

            // rightPnl (Panel bên trái)
            rightPnl = new Panel
            {
                BackColor = Color.FromArgb(144, 238, 144), // Xanh lá nhạt
                Width = 150,
                Dock = DockStyle.Left
            };
            signInPnl.Controls.Add(rightPnl);

            // txtPnl (Khu vực nhập thông tin)
            txtPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            signInPnl.Controls.Add(txtPnl);

            // Tiêu đề
            var titleLbl = new Label
            {
                Text = "Đăng Nhập",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.DarkGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };
            txtPnl.Controls.Add(titleLbl);

            // Email Label
            var emailLbl = new Label
            {
                Text = "Email",
                Font = new Font("Segoe UI", 14),
                Location = new Point(200, 100)
            };
            txtPnl.Controls.Add(emailLbl);

            // Email Field
            emailField = new TextBox
            {
                Width = 250,
                Location = new Point(200, 130),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtPnl.Controls.Add(emailField);

            // Password Label
            var passLbl = new Label
            {
                Text = "Mật Khẩu",
                Font = new Font("Segoe UI", 14),
                Location = new Point(200, 180)
            };
            txtPnl.Controls.Add(passLbl);

            // Password Field
            passField = new TextBox
            {
                Width = 250,
                Location = new Point(200, 210),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '*'
            };
            txtPnl.Controls.Add(passField);

            // Nút Đăng nhập
            signInBtn = new Button
            {
                Text = "Đăng nhập",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 149, 237), // Xanh dương
                ForeColor = Color.White,
                Location = new Point(200, 270),
                Width = 250,
                Height = 40,
                FlatStyle = FlatStyle.Flat
            };
            signInBtn.FlatAppearance.BorderSize = 0;
            txtPnl.Controls.Add(signInBtn);

            // bottomPnl (Panel chứa Đăng ký)
            bottomPnl = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.LightGray
            };
            signInPnl.Controls.Add(bottomPnl);

            var noAccountLbl = new Label
            {
                Text = "Bạn chưa có tài khoản?",
                Font = new Font("Segoe UI", 12),
                Location = new Point(10, 15),
                AutoSize = true
            };
            bottomPnl.Controls.Add(noAccountLbl);

            signUpBtn = new Button
            {
                Text = "Đăng ký",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(192, 192, 192), // Xám
                ForeColor = Color.Black,
                Location = new Point(180, 10),
                Width = 100,
                Height = 30,
                FlatStyle = FlatStyle.Flat
            };
            signUpBtn.FlatAppearance.BorderSize = 0;
            bottomPnl.Controls.Add(signUpBtn);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInForm());
        }
    }
}
