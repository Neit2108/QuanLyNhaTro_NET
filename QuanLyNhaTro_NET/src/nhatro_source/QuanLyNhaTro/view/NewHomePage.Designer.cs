//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;
//using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
//using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;

//namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
//{
//    partial class NewHomePage : UserControl
//    {
//        private TableLayoutPanel Layout;
//        private BorderStyle BorderStyle;

//        private void InitializeComponent()
//        {
//            this.Layout = new TableLayoutPanel
//            {
//                ColumnCount = 3,
//                RowCount = 0,
//                Dock = DockStyle.Fill,
//                Padding = new Padding(10),
//                AutoScroll = true,
//            };

//            this.BorderStyle = BorderStyle.FixedSingle;

//            // Hiển thị thông tin phòng
//            var phongDAO = new PhongDAOImpl();
//            var nhaTroDAO = new NhaTroDAOImpl();
//            List<NhaTro> nhaTroList = nhaTroDAO.GetAllNhaTroByMaChuNha(10);
//            int j = 0;

//            foreach (var x in nhaTroList)
//            {
//                List<Phong> phongs = phongDAO.GetAllPhongByMaNhaTro(x.MaNhaTro);

//                foreach (var phong in phongs)
//                {
//                    if (j == 8)
//                    {
//                        break;
//                    }

//                    var kieuPhongDAO = new KieuPhongDAOImpl();
//                    string loaiPhong = kieuPhongDAO.GetKieuPhong(phong.MaKieuPhong).LoaiPhong;

//                    if (phong.TrangThai.Equals("Chưa thuê", StringComparison.OrdinalIgnoreCase))
//                    {
//                        j++;
//                        this.Controls.Add(CreatePhongPanel(phong.MaPhong, phong.TenPhong, phong.MaNhaTro, loaiPhong, phongDAO.GetGiaPhong(phong.MaPhong), phong.UrlImage));
//                    }
//                }
//            }
//        }

//        private Panel CreatePhongPanel(int maPhong, string tenPhong, int maNhaTro, string loaiPhong, double giaPhong, string anhPhong)
//        {
//            var phongPanel = new Panel
//            {
//                BorderStyle = BorderStyle.FixedSingle,
//                Size = new Size(200, 250),
//                Margin = new Padding(5),
//            };

//            var imageLabel = new PictureBox
//            {
//                BorderStyle = BorderStyle.FixedSingle,
//                Size = new Size(150, 120),
//                SizeMode = PictureBoxSizeMode.StretchImage,
//                Image = Image.FromFile("D:\\MyProjects\\final_QuanLyNhaTro\\src\\resources\\house_619153.png"),
//            };

//            phongPanel.Controls.Add(imageLabel);
//            imageLabel.Dock = DockStyle.Top;

//            var infoPanel = new Panel
//            {
//                Dock = DockStyle.Fill,
//                Padding = new Padding(5),
//            };

//            phongPanel.Controls.Add(infoPanel);

//            var detailInfoPanel = new TableLayoutPanel
//            {
//                RowCount = 4,
//                ColumnCount = 1,
//                Dock = DockStyle.Top,
//            };

//            detailInfoPanel.Controls.Add(new Label { Text = "Tên Phòng: " + tenPhong, AutoSize = true });
//            detailInfoPanel.Controls.Add(new Label { Text = "Nhà Trọ: " + maNhaTro, AutoSize = true });
//            detailInfoPanel.Controls.Add(new Label { Text = "Loại Phòng: " + loaiPhong, AutoSize = true });
//            detailInfoPanel.Controls.Add(new Label { Text = "Giá: " + giaPhong, AutoSize = true });

//            infoPanel.Controls.Add(detailInfoPanel);

//            var buttonPanel = new FlowLayoutPanel
//            {
//                FlowDirection = FlowDirection.RightToLeft,
//                Dock = DockStyle.Bottom,
//            };

//            var chiTietBtn = CreateDetailButton("Chi Tiết");
//            chiTietBtn.Click += (sender, e) =>
//            {
//                var detailRoom = new DetailRoom();//maPhong);
//                detailRoom.ShowDialog();
//            };

//            buttonPanel.Controls.Add(chiTietBtn);
//            infoPanel.Controls.Add(buttonPanel);

//            return phongPanel;
//        }

//        private Button CreateDetailButton(string text)
//        {
//            return new Button
//            {
//                Text = text,
//                Font = new Font("Arial", 12, FontStyle.Regular),
//                Size = new Size(80, 30),
//            };
//        }
//    }
//}

using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class NewHomePage : UserControl
    {
        private TableLayoutPanel Layout;
        private BorderStyle BorderStyle;

        private void InitializeComponent()
        {
            this.Layout = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 0,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoScroll = true,
            };

            this.BorderStyle = BorderStyle.FixedSingle;

            // Hiển thị thông tin phòng
            var phongDAO = new PhongDAOImpl();
            var nhaTroDAO = new NhaTroDAOImpl();
            List<NhaTro> nhaTroList = nhaTroDAO.GetAllNhaTroByMaChuNha(10);
            Layout.RowCount = (int)Math.Ceiling(nhaTroList.Count / 3.0); // hoặc số lượng hàng thích hợp
            int j = 0;

            foreach (var x in nhaTroList)
            {
                List<Phong> phongs = phongDAO.GetAllPhongByMaNhaTro(x.MaNhaTro);

                foreach (var phong in phongs)
                {
                    if (j == 8)
                    {
                        break;
                    }

                    var kieuPhongDAO = new KieuPhongDAOImpl();
                    string loaiPhong = kieuPhongDAO.GetKieuPhong(phong.MaKieuPhong).LoaiPhong;

                    if (phong.TrangThai.Equals("Chưa thuê", StringComparison.OrdinalIgnoreCase))
                    {
                        j++;
                        // Thêm panel phòng vào Layout thay vì this.Controls
                        Layout.Controls.Add(CreatePhongPanel(phong.MaPhong, phong.TenPhong, phong.MaNhaTro, loaiPhong, phongDAO.GetGiaPhong(phong.MaPhong), phong.UrlImage));
                    }
                }
            }

            // Thêm Layout vào UserControl
            this.Controls.Add(Layout);
        }

        private Panel CreatePhongPanel(int maPhong, string tenPhong, int maNhaTro, string loaiPhong, double giaPhong, string anhPhong)
        {
            var phongPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(200, 250),
                Margin = new Padding(5),
            };


            var imageLabel = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(150, 120),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile("D:\\MyProjects\\final_QuanLyNhaTro\\src\\resources\\house_619153.png"),
            };

            phongPanel.Controls.Add(imageLabel);
            imageLabel.Dock = DockStyle.Top;

            var infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
            };

            phongPanel.Controls.Add(infoPanel);

            var detailInfoPanel = new TableLayoutPanel
            {
                RowCount = 4,
                ColumnCount = 1,
                Dock = DockStyle.Top,
            };

            detailInfoPanel.Controls.Add(new Label { Text = "Tên Phòng: " + tenPhong, AutoSize = true });
            detailInfoPanel.Controls.Add(new Label { Text = "Nhà Trọ: " + maNhaTro, AutoSize = true });
            detailInfoPanel.Controls.Add(new Label { Text = "Loại Phòng: " + loaiPhong, AutoSize = true });
            detailInfoPanel.Controls.Add(new Label { Text = "Giá: " + giaPhong, AutoSize = true });

            infoPanel.Controls.Add(detailInfoPanel);

            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
            };

            var chiTietBtn = CreateDetailButton("Chi Tiết");
            chiTietBtn.Click += (sender, e) =>
            {
                var detailRoom = new DetailRoom();//maPhong);
                detailRoom.ShowDialog();
            };

            buttonPanel.Controls.Add(chiTietBtn);
            infoPanel.Controls.Add(buttonPanel);

            return phongPanel;
        }

        private Button CreateDetailButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(80, 30),
            };
        }
    }
}