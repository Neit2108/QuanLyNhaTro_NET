using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller
{
    public class DetailRoomController
    {
        private readonly DetailRoom detailRoom;
        private readonly IPhongDAO phongDAO;

        public DetailRoomController(DetailRoom detailRoom)
        {
            this.detailRoom = detailRoom;
            this.phongDAO = new PhongDAOImpl();
        }

        public void Init(int maPhong)
        {
            //if (!Constant.Role.Equals("Khách thuê", StringComparison.OrdinalIgnoreCase))
            //{
            //    detailRoom.ThuephongBtn.Visible = false;
            //}

            Phong phong = phongDAO.GetPhong(maPhong);
            if (phong.TrangThai.Equals("Đã thuê", StringComparison.OrdinalIgnoreCase))
            {
                detailRoom.ThuephongBtn.Visible = false;
            }

            detailRoom.ThuephongBtn.Click += (sender, e) => HandleThuePhongBtn(maPhong);
            HandleDetailRoom(maPhong);
        }

        public void HandleDetailRoom(int maPhong)
        {
            Phong phong = phongDAO.GetPhong(maPhong);

            // Set image
            detailRoom.ImageLbl.Size = new Size(200, 200);
            try
            {
                using (Image originalImage = Image.FromFile(phong.UrlImage))
                {
                    Image resizedImage = new Bitmap(originalImage, new Size(200, 200));
                    detailRoom.ImageLbl.Image = resizedImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
            }

            // Set service list
            IPhong_DichVu_DAO phong_dichVu_dao = new Phong_DichVu_DAOImpl();
            detailRoom.DetailServiceList.DataSource = phong_dichVu_dao.GetAllTrangThaiPhong(maPhong);

            // Set room price in table
            IKieuPhongDAO kieuPhongDAO = new KieuPhongDAOImpl();
            KieuPhong kieuPhong = kieuPhongDAO.GetKieuPhong(phong.MaKieuPhong);
            double price = kieuPhong.GiaPhong;
            double area = kieuPhong.DienTich;

            detailRoom.Table1.Rows[1].Cells[1].Value = $"{area:0.##} (m2)";
            detailRoom.Table1.Rows[2].Cells[1].Value = $"{price:0.##} (tháng)";
            detailRoom.Show();
        }

        private void HandleThuePhongBtn(int maPhong)
        {
            Phong phong = phongDAO.GetPhong(maPhong);
            if (phong.TrangThai.Equals("Đã thuê", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Phòng đã được thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thuê phòng này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    IKhachThueDAO khachThueDAO = new KhachThueDAOImpl();
                    KhachThue khachThue = khachThueDAO.GetKhachThue(
                        new TaiKhoanDAOImpl().GetMaKhachThue(Constant.TaiKhoan.MaTaiKhoan));

                    string tenKhachThue = khachThue.Ten ?? "Lê Anh Khoa";
                    string txt = $"Khách hàng {tenKhachThue} đã gửi yêu cầu thuê phòng {phong.TenPhong} (Mã phòng: {phong.MaPhong}) cho bạn";

                    int maChuNha = phongDAO.GetMaChuNha(maPhong);
                    IChuNhaDAO chuNhaDAO = new ChuNhaDAOImpl();
                    ChuNha chuNha = chuNhaDAO.GetChuNhaByMa(maChuNha);

                    IThongBaoDAO thongBaoDAO = new ThongBaoDAOImpl();
                    thongBaoDAO.AddThongBao(
                        Constant.TaiKhoan.MaTaiKhoan,
                        chuNha.MaTaiKhoan,
                        txt,
                        "Chưa xem",
                        maPhong,
                        "ThuePhong");

                    MessageBox.Show(
                        "Yêu cầu thuê phòng đã được gửi đến chủ nhà",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
    }
}