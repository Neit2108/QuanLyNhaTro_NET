using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class SignInForm : Form
    {
        private Panel signInPnl;
        private TextBox emailField;
        private TextBox passField;
        private Button signInBtn;
        private Button signUpBtn;
        private Panel rightPnl;
        private Panel txtPnl;
        private Label emailLbl;
        private Label passLbl;

        public SignInForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Panel for sign in form
            signInPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };

            // Left panel
            rightPnl = new Panel
            {
                BackColor = Color.FromArgb(144, 238, 144), // Light green color
                Width = 150,
                Height = 400,
                Dock = DockStyle.Left
            };
            signInPnl.Controls.Add(rightPnl);

            // Panel for text fields and labels
            txtPnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Title label
            Label titleLbl = new Label
            {
                Text = "Đăng Nhập",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.DarkGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            txtPnl.Controls.Add(titleLbl);

            // Email label
            emailLbl = new Label
            {
                Text = "Email",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Width = 100
            };
            txtPnl.Controls.Add(emailLbl);

            // Email field
            emailField = new TextBox
            {
                Width = 200
            };
            txtPnl.Controls.Add(emailField);

            // Password label
            passLbl = new Label
            {
                Text = "Mật Khẩu",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Width = 100
            };
            txtPnl.Controls.Add(passLbl);

            // Password field
            passField = new TextBox
            {
                Width = 200,
                PasswordChar = '*'
            };
            txtPnl.Controls.Add(passField);

            // Sign in button
            signInBtn = new Button
            {
                Text = "Đăng nhập",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Width = 200
            };
            txtPnl.Controls.Add(signInBtn);

            // Add text panel to sign in panel
            signInPnl.Controls.Add(txtPnl);

            // Bottom panel for sign up
            Panel bottomPnl = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.LightGray
            };

            Label noAccountLbl = new Label
            {
                Text = "Bạn chưa có tài khoản?",
                Font = new Font("Segoe UI", 12)
            };
            bottomPnl.Controls.Add(noAccountLbl);

            signUpBtn = new Button
            {
                Text = "Đăng ký",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.Black
            };
            bottomPnl.Controls.Add(signUpBtn);

            signInPnl.Controls.Add(bottomPnl);

            // Form settings
            this.Controls.Add(signInPnl);
            this.Text = "Sign In";
            this.Size = new Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInForm());
        }
    }
}