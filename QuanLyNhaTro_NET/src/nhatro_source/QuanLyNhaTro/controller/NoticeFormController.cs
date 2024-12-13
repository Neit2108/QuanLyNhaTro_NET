using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class NoticeFormController
    {
        private readonly NoticeForm noticeForm;
        private readonly IThongBaoDAO thongBaoDAO;

        public NoticeFormController(NoticeForm noticeForm)
        {
            this.noticeForm = noticeForm;
            this.thongBaoDAO = new ThongBaoDAOImpl();
        }

        public void Init()
        {
            HandleTable();

            // Add mouse click handlers for the table
            noticeForm.Table.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == 4) // Checkbox column
                {
                    HandleCheckBox(e.RowIndex, e.ColumnIndex);
                }
            };

            noticeForm.Table.CellDoubleClick += (sender, e) =>
            {
                HandleClickOnTable(e.RowIndex);
            };

            noticeForm.BtnDeleteAll.Click += (sender, e) =>
            {
                thongBaoDAO.DeleteAllThongBao(Constant.TaiKhoan.MaTaiKhoan);
                while (noticeForm.Table.Rows.Count > 0)
                {
                    noticeForm.Table.Rows.RemoveAt(0);
                }
            };
        }

        private void HandleTable()
        {
            List<ThongBao> thongBaoList = thongBaoDAO.GetAllThongBao(Constant.TaiKhoan.MaTaiKhoan);
            int i = 1;
            foreach (var x in thongBaoList)
            {
                noticeForm.Table.Rows.Add(
                    x.Id,
                    i++,
                    x.NoiDung,
                    x.NgayTao.ToString("dd/MM/yyyy"), // Format the date
                    x.TrangThai.Equals("Chưa xem", StringComparison.OrdinalIgnoreCase) ? false : true
                );
            }
        }

        private void HandleCheckBox(int row, int col)
        {
            if (col == 4 && row >= 0)
            {
                bool check = (bool)noticeForm.Table.Rows[row].Cells[col].Value;
                if (check)
                {
                    noticeForm.Table.Rows[row].Cells[col].Value = true;
                    int id = Convert.ToInt32(noticeForm.Table.Rows[row].Cells[0].Value);
                    thongBaoDAO.UpdateTrangThaiThongBao(id);
                    noticeForm.Table.Refresh();
                }
                else
                {
                    noticeForm.Table.Rows[row].Cells[col].Value = false;
                }
            }
        }

        private void HandleClickOnTable(int row)
        {
            if (row < 0) return;

            int id = Convert.ToInt32(noticeForm.Table.Rows[row].Cells[0].Value);
            ThongBao thongBao = thongBaoDAO.GetThongBao(id);
            string txt = $"Nội dung: {thongBao.NoiDung}\n" +
                        $"Ngày nhận: {thongBao.NgayTao}\n" +
                        $"Trạng thái: {thongBao.TrangThai}\n";

            if (Constant.Role.Equals("Chủ nhà", StringComparison.OrdinalIgnoreCase))
            {
                HandleLandlordNotification(thongBao, txt, row, id);
            }
            else if (Constant.Role.Equals("Khách thuê", StringComparison.OrdinalIgnoreCase))
            {
                HandleTenantNotification(thongBao, txt, row, id);
            }
        }

        private void HandleLandlordNotification(ThongBao thongBao, string txt, int row, int id)
        {
            string loaiThongBao = thongBao.LoaiThongBao ?? "ThuePhong";

            if (loaiThongBao.Equals("ThuePhong", StringComparison.OrdinalIgnoreCase))
            {
                DialogResult result = MessageBox.Show(txt, "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    HandleRentalRequest(thongBao, row, id);
                }
                else
                {
                    HandleRentalRejection(thongBao, row, id);
                }
            }
            else if (loaiThongBao.Equals("ThanhToan", StringComparison.OrdinalIgnoreCase))
            {
                HandlePaymentNotification(row, id);
            }
        }

        private void HandleTenantNotification(ThongBao thongBao, string txt, int row, int id)
        {
            if (thongBao.TrangThai.Equals("YeuCauThuePhong", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(txt);
                UpdateNotificationStatus(row, id);
            }
            else if (thongBao.TrangThai.Equals("YeuCauThanhToan", StringComparison.OrdinalIgnoreCase))
            {
                DialogResult result = MessageBox.Show(txt, "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    UpdateNotificationStatus(row, id);
                    // Show payment form
                    // TODO: Implement payment form display
                }
            }
        }

        private void UpdateNotificationStatus(int row, int id)
        {
            noticeForm.Table.Rows[row].Cells[4].Value = true;
            thongBaoDAO.UpdateTrangThaiThongBao(id);
        }

        private void HandleRentalRequest(ThongBao thongBao, int row, int id)
        {
            // TODO: Implement rental contract form
            // This would be similar to your Java InforContractForm implementation
            MessageBox.Show("Implementing rental contract form...");
        }

        private void HandleRentalRejection(ThongBao thongBao, int row, int id)
        {
            thongBaoDAO.UpdateTrangThaiThongBao(id);
            string rejectMessage = $"Yêu cầu thuê phòng {new PhongDAOImpl().GetPhong(thongBao.MaPhong).TenPhong} " +
                                 $"(Mã phòng : {thongBao.MaPhong}) của bạn đã bị từ chối";
            thongBaoDAO.AddThongBao(Constant.TaiKhoan.MaTaiKhoan, thongBao.MaNguoiGui,
                rejectMessage, "Chưa xem", thongBao.MaPhong, "YeuCauThuePhong");
            UpdateNotificationStatus(row, id);
            MessageBox.Show("Đã từ chối yêu cầu thuê phòng");
        }

        private void HandlePaymentNotification(int row, int id)
        {
            UpdateNotificationStatus(row, id);
        }
    }
}