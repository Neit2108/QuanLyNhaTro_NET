using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;


namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class MenuFormController
    {
        private readonly MenuForm menuForm;
        private SignInForm signInForm;

        public MenuFormController(MenuForm menuForm)
        {
            this.menuForm = menuForm;
            Init();
        }

        public void Init()
        {
            if ((Constant.Role != null ? Constant.Role : "Admin").Equals("Khách Thuê", StringComparison.OrdinalIgnoreCase))
            {
                this.menuForm.NhaBtn.Visible = false;
                this.menuForm.QuanlyBtn.Visible = false;
            }

            this.menuForm.DangxuatBtn.Click += HandleDangXuatBtn;
            //this.menuForm.HomePageBtn.Click += HandleHomePageBtn;
            //this.menuForm.QuanlyBtn.Click += HandleKhachThueBtn;
            //this.menuForm.PctBtn.Click += HandleQuanLyPhongBtn;
            //this.menuForm.HopdongBtn.Click += HandleContractBtn;
            //this.menuForm.HoadonBtn.Click += HandleInvoiceBtn;
            //this.menuForm.NhaBtn.Click += HandleHouseBtn;
            //this.menuForm.ThongbaoBtn.Click += HandleNoticeBtn;
            this.menuForm.CircularPictureBox.MouseClick -= HandleUserLbl; 
            this.menuForm.CircularPictureBox.MouseClick += HandleUserLbl;

        }

        private void HandleDangXuatBtn(object sender, EventArgs e)
        {
            try
            {
                this.menuForm.Hide();
                if(signInForm == null || signInForm.IsDisposed)
                {
                    signInForm = new SignInForm();
                    signInForm.Show();
                }
                else
                {
                    signInForm.Activate();
                }

                this.menuForm.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error logging out", ex);
            }
        }

        //private void HandleKhachThueBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "QuanLyKhachThue");
        //}

        //private void HandleQuanLyPhongBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "QuanLyPhong");
        //}

        //private void HandleHomePageBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "HomePage");
        //}

        //private void HandleContractBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "HopDong");
        //}

        //private void HandleInvoiceBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "HoaDon");
        //}

        //private void HandleHouseBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "Nha");
        //}

        //private void HandleNoticeBtn(object sender, EventArgs e)
        //{
        //    this.menuForm.CardLayout.Show(this.menuForm.MainPanel, "ThongBao");
        //}

       

        private void HandleUserLbl(object sender, MouseEventArgs e)
        {
            AccountInforForm accountForm = null;
            // Kiểm tra nếu form chưa mở, thì mở mới
            if (accountForm == null || accountForm.IsDisposed)
            {
                accountForm = new AccountInforForm();
                accountForm.Show();
            }
            else
            {
                // Form đã mở rồi, không làm gì
                accountForm.Activate(); // Kích hoạt lại form nếu đã mở
            }
        }

    }
}
