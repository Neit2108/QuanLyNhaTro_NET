using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class MenuForm : Form
    {
        private Button homePageBtn;
        private Button dangxuatBtn;
        private Button quanlyBtn;
        private Button hopdongBtn;
        private Button nhaBtn;
        private Button pctBtn;
        private Button hoadonBtn;
        private Button thongbaoBtn;
        private Panel buttonPanel;
        private Panel mainPanel;
        private PictureBox circularPictureBox;

        private void InitializeComponents()
        { 
            this.Text = "Menu Form";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Size = new Size(800, 600);
            this.WindowState = FormWindowState.Maximized;

            buttonPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.FromArgb(240, 248, 255)
            };

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Label menuLabel = new Label
            {
                Text = "Menu",
                Font = new Font("Arial", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            homePageBtn = CreateRoundedButton("Trang chủ");
            pctBtn = CreateRoundedButton("Quản lý phòng");
            nhaBtn = CreateRoundedButton("Nhà");
            hopdongBtn = CreateRoundedButton("Hợp Đồng");
            quanlyBtn = CreateRoundedButton("Quản Lý Khách Thuê");
            hoadonBtn = CreateRoundedButton("Hóa đơn");
            thongbaoBtn = CreateRoundedButton("Thông báo");
            dangxuatBtn = CreateRoundedButton("Đăng Xuất");

            dangxuatBtn.Size = new Size(100, 40);
            dangxuatBtn.Font = new Font("Arial", 10, FontStyle.Bold);

            Image image = Image.FromFile(@"D:\\MyProjects\\QuanLyNhaTro_NET\\QuanLyNhaTro_NET\\Resources\\user_icon.png");
            circularPictureBox = new PictureBox
            {
                Size = new Size(60, 60),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = image,
                Dock = DockStyle.Top
            };

            SetCircularPictureBox(circularPictureBox);

            FlowLayoutPanel buttonContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false,
                Padding = new Padding(10, 10, 10, 10)
            };

            Button[] buttons = new Button[]
            {
                homePageBtn, pctBtn, nhaBtn, hopdongBtn,
                quanlyBtn, hoadonBtn, thongbaoBtn
            };

            foreach (Button btn in buttons)
            {
                btn.Margin = new Padding(5);
                buttonContainer.Controls.Add(btn);
            }

            Panel userPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 100,  // Reduced height
                BackColor = Color.FromArgb(230, 230, 250)
            };

            circularPictureBox = new PictureBox
            {
                Size = new Size(40, 40),  
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = image
            };

            dangxuatBtn.Size = new Size(75, 30); 
            dangxuatBtn.Font = new Font("Arial", 9, FontStyle.Bold);  

            circularPictureBox.Location = new Point(
                (userPanel.Width - circularPictureBox.Width) / 2,
                10  
            );

            dangxuatBtn.Location = new Point(
                (userPanel.Width - dangxuatBtn.Width) / 2,
                circularPictureBox.Bottom + 5  
            );

            userPanel.Controls.Add(circularPictureBox);
            userPanel.Controls.Add(dangxuatBtn);

            circularPictureBox.Dock = DockStyle.None;
            dangxuatBtn.Dock = DockStyle.None;

            buttonPanel.Controls.Add(buttonContainer);
            buttonPanel.Controls.Add(userPanel);
            buttonPanel.Controls.Add(menuLabel);

            this.Controls.Add(buttonPanel);
            this.Controls.Add(mainPanel);
        }

        private Button CreateRoundedButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Size = new Size(150, 60),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(135, 206, 250),
                ForeColor = Color.Black,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            button.FlatAppearance.BorderSize = 0;
            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 30, 30));

            return button;
        }

        private void SetCircularPictureBox(PictureBox pb)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
            pb.Region = new Region(gp);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        public Button HomePageBtn
        {
            get { return homePageBtn; }
            set { homePageBtn = value; }
        }

        public Button DangxuatBtn
        {
            get { return dangxuatBtn; }
            set { dangxuatBtn = value; }
        }

        public Button QuanlyBtn
        {
            get { return quanlyBtn; }
            set { quanlyBtn = value; }
        }

        public Button HopdongBtn
        {
            get { return hopdongBtn; }
            set { hopdongBtn = value; }
        }

        public Button NhaBtn
        {
            get { return nhaBtn; }
            set { nhaBtn = value; }
        }

        public Button PctBtn
        {
            get { return pctBtn; }
            set { pctBtn = value; }
        }

        public Button HoadonBtn
        {
            get { return hoadonBtn; }
            set { hoadonBtn = value; }
        }

        public Button ThongbaoBtn
        {
            get { return thongbaoBtn; }
            set { thongbaoBtn = value; }
        }

        public Panel ButtonPanel
        {
            get { return buttonPanel; }
            set { buttonPanel = value; }
        }

        public Panel MainPanel
        {
            get { return mainPanel; }
            set { mainPanel = value; }
        }

        public PictureBox CircularPictureBox
        {
            get { return circularPictureBox; }
            set { circularPictureBox = value; }
        }
    }
}
