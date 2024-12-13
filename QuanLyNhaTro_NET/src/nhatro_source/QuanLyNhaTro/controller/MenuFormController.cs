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
        private NoticeForm noticeForm;
        private NewHomePage homePage;
        private ContractForm contractForm;
        private InvoiceForm invoiceForm;
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
            this.menuForm.HomePageBtn.Click += HomePageBtn_Click;
            this.menuForm.ThongbaoBtn.Click += ThongbaoBtn_Click;
            this.menuForm.HopdongBtn.Click += ContractBtn_Click;
            this.menuForm.HoadonBtn.Click += InvoiceBtn_Click;
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

        private void HandleUserLbl(object sender, MouseEventArgs e)
        {
            AccountInforForm accountForm = null;
            if (accountForm == null || accountForm.IsDisposed)
            {
                accountForm = new AccountInforForm();
                accountForm.Show();
            }
            else
            {
                accountForm.Activate();
            }
        }

        private void ThongbaoBtn_Click(object sender, EventArgs e)
        {
            menuForm.MainPanel.Controls.Clear();
            if (noticeForm == null || noticeForm.IsDisposed)
            {
                noticeForm = new NoticeForm();
            }
            noticeForm.Dock = DockStyle.Fill;
            noticeForm.Margin = new Padding(0);
            menuForm.MainPanel.Controls.Add(noticeForm);
            UpdateButtonStates(menuForm.ThongbaoBtn);
        }

        private void HomePageBtn_Click(object sender, EventArgs e)
        {
            menuForm.MainPanel.Controls.Clear();
            if (homePage == null || homePage.IsDisposed)
            {
                homePage = new NewHomePage();
            }
            homePage.Dock = DockStyle.Fill;
            homePage.Margin = new Padding(0);
            menuForm.MainPanel.Controls.Add(homePage);
            UpdateButtonStates(menuForm.HomePageBtn);
        }

        private void ContractBtn_Click(Object sender, EventArgs e)
        {
            menuForm.MainPanel.Controls.Clear();
            if(contractForm == null || contractForm.IsDisposed)
            {
                contractForm = new ContractForm();
            }
            contractForm.Dock = DockStyle.Fill;
            contractForm.Margin = new Padding(0);
            menuForm.MainPanel.Controls.Add(contractForm);
            UpdateButtonStates(menuForm.HopdongBtn);
        }

        private void InvoiceBtn_Click(object sender, EventArgs e)
        {
            menuForm.MainPanel.Controls.Clear();
            if (invoiceForm == null || invoiceForm.IsDisposed)
            {
                invoiceForm = new InvoiceForm();
            }
            invoiceForm.Dock = DockStyle.Fill;
            invoiceForm.Margin = new Padding(0);
            menuForm.MainPanel.Controls.Add(invoiceForm);
            UpdateButtonStates(menuForm.HoadonBtn);
        }

        private void UpdateButtonStates(Button activeButton)
        {
            // Reset all buttons to default state
            Button[] buttons = new Button[]
            {
            menuForm.HomePageBtn,
            menuForm.PctBtn,
            menuForm.NhaBtn,
            menuForm.HopdongBtn,
            menuForm.QuanlyBtn,
            menuForm.HoadonBtn,
            menuForm.ThongbaoBtn
            };

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.FromArgb(135, 206, 250); // Default color
            }

            // Highlight active button
            activeButton.BackColor = Color.FromArgb(70, 130, 180); // Darker blue for active button
        }

    }
}
