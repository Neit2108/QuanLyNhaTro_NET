using System;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class DetailInvoiceController
    {
        private readonly DetailInvoiceForm detailInvoiceForm;
        private readonly InvoiceForm invoiceForm;

        public DetailInvoiceController(DetailInvoiceForm detailInvoiceForm, InvoiceForm invoiceForm)
        {
            this.detailInvoiceForm = detailInvoiceForm;
            this.invoiceForm = invoiceForm;
        }

        public void Init()
        {
            int i = this.invoiceForm.MainTable.CurrentRow.Index;
            int maHopDong = Convert.ToInt32(this.invoiceForm.MainTable.Rows[i].Cells[1].Value);
            int maPhong = Convert.ToInt32(this.invoiceForm.MainTable.Rows[i].Cells[2].Value);

            HandleInfor(maHopDong, maPhong);
            HandleTableUsedService(maHopDong, maPhong);
            HandleTotal(maPhong);

            this.detailInvoiceForm.PayBtn.Click += (s, e) => HandleThanhToanBtn(e, i);
        }

        private void HandleInfor(int maHopDong, int maPhong)
        {
            IHopDongDAO hopDongDAO = new HopDongDAOImpl();
            HopDong hopDong = hopDongDAO.GetHopDong(maHopDong);

            this.detailInvoiceForm.NumberOfMemberField.Text = hopDong.SoNguoi.ToString();
            this.detailInvoiceForm.AddressLbl.Text = "Địa chỉ : Hà Noi";
            this.detailInvoiceForm.NumberOfRoomLbl.Text = "PHÒNG SỐ " + maPhong;
            this.detailInvoiceForm.CleanField.Text = "50000";
            this.detailInvoiceForm.VehicleField.Text = "50000";
            this.detailInvoiceForm.InternetField.Text = "100000";
            this.detailInvoiceForm.ElecField.Text = "4000";
            this.detailInvoiceForm.WaterField.Text = "30000";
        }

        private void HandleTableUsedService(int maHopDong, int maPhong)
        {
            ITienThuDAO tienThuDAO = new TienThuDAOImpl();
            TienThuTienIch tienThuTienIch = tienThuDAO.GetTienThu(maPhong);

            ((DataGridView)detailInvoiceForm.UsedServiceTbl).Rows.Add(new object[]
            {
                "Dịch vụ điện",
                tienThuTienIch.SoDienMoi,
                tienThuTienIch.SoDienCu,
                tienThuTienIch.SoDienDaDung,
                "4000",
                tienThuTienIch.SoDienDaDung * 4000
            });

            ((DataGridView)detailInvoiceForm.UsedServiceTbl).Rows.Add(new object[]
            {
                "Dịch vụ nước",
                tienThuTienIch.SoNuocMoi,
                tienThuTienIch.SoNuocCu,
                tienThuTienIch.SoNuocDaDung,
                "30000",
                tienThuTienIch.SoNuocDaDung * 30000
            });
        }

        private void HandleTotal(int maPhong)
        {
            IPhongDAO phongDAO = new PhongDAOImpl();
            double giaPhong = phongDAO.GetGiaPhong(maPhong);

            this.detailInvoiceForm.TotalField.Text =
                this.invoiceForm.MainTable.Rows[this.invoiceForm.MainTable.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void HandleThanhToanBtn(EventArgs e, int selectedRow)
        {
            IThanhToanDAO thanhToanDAO = new ThanhToanDAOImpl();
            string hinhThuc = this.detailInvoiceForm.PaymentCombo.SelectedItem.ToString();
            string trangThai = this.invoiceForm.MainTable.Rows[selectedRow].Cells[4].Value.ToString();

            if (trangThai.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Hóa đơn đã được thanh toán");
                return;
            }

            if (!hinhThuc.Equals("Chuyển Khoản", StringComparison.OrdinalIgnoreCase))
            {
                string txt = $"Đã gửi yêu cầu thanh toán số tiền : {this.detailInvoiceForm.TotalField.Text} bằng hình thức : {hinhThuc} cho chủ nhà";
                MessageBox.Show(txt);

                IThongBaoDAO thongBaoDAO = new ThongBaoDAOImpl();
                IPhongDAO phongDAO = new PhongDAOImpl();
                int maChuNha = phongDAO.GetMaChuNha(Convert.ToInt32(this.invoiceForm.MainTable.Rows[selectedRow].Cells[2].Value));
                ChuNha chuNha = new ChuNhaDAOImpl().GetChuNhaByMa(maChuNha);

                string txt2 = $"Yêu cầu thanh toán số tiền : {this.detailInvoiceForm.TotalField.Text} bằng hình thức : {hinhThuc} " +
                            $"cho hóa đơn mã {this.invoiceForm.MainTable.Rows[selectedRow].Cells[0].Value} đã được gửi tới bạn";

                thongBaoDAO.AddThongBao(
                    Constant.TaiKhoan.MaTaiKhoan,
                    chuNha.MaTaiKhoan,
                    txt2,
                    "Chưa xem",
                    Convert.ToInt32(this.invoiceForm.MainTable.Rows[selectedRow].Cells[2].Value),
                    "ThanhToan"
                );
            }
            else
            {
                int maHoaDon = Convert.ToInt32(this.invoiceForm.MainTable.Rows[selectedRow].Cells[0].Value);
                PaymentDetailsForm paymentDetailsForm = new PaymentDetailsForm(maHoaDon);

                IPhongDAO phongDAO = new PhongDAOImpl();
                int maChuNha = phongDAO.GetMaChuNha(Convert.ToInt32(this.invoiceForm.MainTable.Rows[selectedRow].Cells[2].Value));
                ChuNha chuNha = new ChuNhaDAOImpl().GetChuNhaByMa(maChuNha);

                paymentDetailsForm.RecipientValue.Text = chuNha.Ten;
                paymentDetailsForm.AmountValue.Text = this.detailInvoiceForm.TotalField.Text;
            }
        }
    }
}