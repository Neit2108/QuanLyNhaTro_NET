using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.dao;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class NewHomePage : UserControl
    {
        private TableLayoutPanel Layout;

        private void InitializeComponent()
        {
            this.Layout = new TableLayoutPanel
            {
                ColumnCount = 3,    // Đảm bảo có 3 cột
                RowCount = 3,       // Đảm bảo có 3 hàng (tổng cộng là 9 ô)
                Dock = DockStyle.Fill,
                Padding = new Padding(5),  // Tăng khoảng cách giữa các phần tử
                AutoScroll = false,    // Tắt cuộn
                Margin = new Padding(0),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single // Thêm viền cho các ô
            };

            // Đảm bảo mỗi cột có chiều rộng đều nhau
            float columnWidth = 33.33F;
            for (int i = 0; i < 3; i++)
            {
                this.Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidth));
            }

            // Đảm bảo các hàng có chiều cao tự động (vừa đủ cho nội dung)
            float rowHeight = 33.33F;
            for (int i = 0; i < 3; i++)
            {
                this.Layout.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }

            this.BorderStyle = BorderStyle.FixedSingle;

            var phongDAO = new PhongDAOImpl();
            var nhaTroDAO = new NhaTroDAOImpl();
            List<NhaTro> nhaTroList = nhaTroDAO.GetAllNhaTroByMaChuNha(10);

            int j = 0;

            foreach (var x in nhaTroList)
            {
                List<Phong> phongs = phongDAO.GetAllPhongByMaNhaTro(x.MaNhaTro);

                foreach (var phong in phongs)
                {
                    if (j == 9)
                    {
                        break;
                    }

                    var kieuPhongDAO = new KieuPhongDAOImpl();
                    string loaiPhong = kieuPhongDAO.GetKieuPhong(phong.MaKieuPhong).LoaiPhong;

                    if (phong.TrangThai.Equals("Chưa thuê", StringComparison.OrdinalIgnoreCase))
                    {
                        j++;
                        Layout.Controls.Add(CreatePhongPanel(phong.MaPhong, phong.TenPhong, phong.MaNhaTro, loaiPhong, phongDAO.GetGiaPhong(phong.MaPhong), phong.UrlImage));
                    }
                }

               
            }

            this.Controls.Add(Layout);
        }

        private Panel CreatePhongPanel(int maPhong, string tenPhong, int maNhaTro, string loaiPhong, double giaPhong, string anhPhong)
        {
            var phongPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5), // Khoảng cách giữa các panel
                AutoSize = true,
                Dock = DockStyle.Fill, // Đảm bảo panel con lấp đầy không gian của parent panel
                Padding = new Padding(0)
            };

            // Tạo vùng hiển thị hình ảnh
            var imageLabel = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom, // Đảm bảo ảnh tỉ lệ phù hợp
                Height = 120, // Điều chỉnh chiều cao ảnh cho phù hợp
                Dock = DockStyle.Top, // Đảm bảo ảnh chiếm phần trên của panel
                Margin = new Padding(5) // Thêm margin để tránh ảnh dính vào các viền
            };

            try
            {
                imageLabel.Image = Image.FromFile(anhPhong);  // Dùng đường dẫn hình ảnh động
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                imageLabel.Image = null;
            }

            var infoPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, // Điều chỉnh infoPanel để chiếm toàn bộ không gian còn lại trong phongPanel
                AutoSize = true,
                Margin = new Padding(5),
                ColumnCount = 1,
                RowCount = 5 // 4 labels + 1 button
            };

            // Thêm labels vào infoPanel
            var labels = new[] {
                new Label { Text = "Tên Phòng: " + tenPhong, AutoSize = true },
                new Label { Text = "Nhà Trọ: " + maNhaTro, AutoSize = true },
                new Label { Text = "Loại Phòng: " + loaiPhong, AutoSize = true },
                new Label { Text = "Giá: " + giaPhong, AutoSize = true }
            };

            // Thêm các label vào infoPanel
            foreach (var label in labels)
            {
                label.Dock = DockStyle.Fill; // Đảm bảo rằng các label sẽ chiếm không gian sẵn có
                label.Margin = new Padding(5);
                infoPanel.Controls.Add(label);
            }

            // Nút Chi Tiết
            var chiTietBtn = new Button
            {
                Text = "Chi Tiết",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Size = new Size(100, 30),
                Margin = new Padding(5),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Dock = DockStyle.None
            };

            chiTietBtn.Click += (sender, e) =>
            {
                var detailRoom = new DetailRoom(maPhong);
                detailRoom.Show();
            };

            // Thêm vào các panel
            infoPanel.Controls.Add(chiTietBtn);
            phongPanel.Controls.Add(infoPanel);
            phongPanel.Controls.Add(imageLabel);
            return phongPanel;
        }

    }
}
