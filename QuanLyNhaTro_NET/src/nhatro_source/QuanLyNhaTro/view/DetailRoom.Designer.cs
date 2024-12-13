using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class DetailRoom : Form
    {
        private Panel MainPnl;
        private Panel imagePnl;
        private Panel detailPnl;
        private ListBox detailServiceList;
        private DataGridView table1;
        private Panel pricePnl;
        private Panel servicePnl;
        private Panel serviceList;
        private Panel scrollPriceTbl;
        private Panel priceTblPnl;
        private PictureBox imageLbl;
        private Label serviceLbl1;
        private Label serviceLbl2;
        private Label serviceLbl3;
        private Label serviceLbl4;
        private Label serviceLbl5;
        private Label serviceLbl6;
        private Label serviceLbl7;
        private Label serviceLbl8;
        private Panel scrollServiceList;
        private Button thuephongBtn;


        private void InitializeComponent()
        {
            this.Text = "Chi tiết phòng";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Initialize main container
            MainPnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            imagePnl = new Panel
            {
                Width = 400,
                Dock = DockStyle.Left,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            imageLbl = new PictureBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            try
            {
                string imagePath = @"D:\MyProjects\final_QuanLyNhaTro\src\resources\dora2.png"; // Replace with your image path
                using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open))
                {
                    imageLbl.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
            }

            imagePnl.Controls.Add(imageLbl);

            // Right side - Details Panel
            detailPnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // Price Panel
            pricePnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 300,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(230, 230, 250)
            };

            table1 = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                AllowUserToResizeColumns = false,  
                AllowUserToResizeRows = false,    
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };

            
            foreach (DataGridViewColumn column in table1.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            table1.ColumnCount = 2;
            table1.Columns[0].Name = "Mục";
            table1.Columns[1].Name = "Chi tiết";

            string[,] data = new string[,] {
        {"Hợp đồng", "Đóng 1 cọc 1"},
        {"Diện tích", "25 (m2)"},
        {"Tiền phòng", "1000000 (tháng)"},
        {"Tiền điện", "4000 (số)"},
        {"Tiền nước", "100000 (người)"},
        {"Tiền vệ sinh", "10000 (người)"},
        {"Tiền thang máy", "100000 (phòng)"},
        {"Tiền wifi", "100000 (phòng)"},
        {"Tiền giữ xe", "50000 (người)"}
    };

            foreach (DataGridViewColumn column in table1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            table1.RowTemplate.Height = 30;
            table1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            table1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            table1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            table1.Font = new Font("Arial", 10);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                table1.Rows.Add(data[i, 0], data[i, 1]);
            }

            pricePnl.Controls.Add(table1);

            // Service Panel
            servicePnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            // Service List
            detailServiceList = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            // Add some sample services
            detailServiceList.Items.AddRange(new string[] {
        "Wifi miễn phí",
        "Dọn vệ sinh hàng tuần",
        "Bảo vệ 24/7",
        "Chỗ để xe",
        "Thang máy"
    });

            servicePnl.Controls.Add(detailServiceList);

            // Rent Button
            thuephongBtn = new Button
            {
                Text = "Thuê Phòng",
                Dock = DockStyle.Bottom,
                Height = 40,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White
            };

            // Add controls to panels
            detailPnl.Controls.Add(servicePnl);
            detailPnl.Controls.Add(pricePnl);
            detailPnl.Controls.Add(thuephongBtn);

            // Add main panels to form
            MainPnl.Controls.Add(detailPnl);
            MainPnl.Controls.Add(imagePnl);
            this.Controls.Add(MainPnl);
        }

        //create getter setter for all components
        public Panel MainPnl1 { get => MainPnl; set => MainPnl = value; }
        public Panel ImagePnl { get => imagePnl; set => imagePnl = value; }
        public Panel DetailPnl { get => detailPnl; set => detailPnl = value; }
        public ListBox DetailServiceList { get => detailServiceList; set => detailServiceList = value; }
        public DataGridView Table1 { get => table1; set => table1 = value; }
        public Panel PricePnl { get => pricePnl; set => pricePnl = value; }
        public Panel ServicePnl { get => servicePnl; set => servicePnl = value; }
        public Panel ServiceList { get => serviceList; set => serviceList = value; }
        public Panel ScrollPriceTbl { get => scrollPriceTbl; set => scrollPriceTbl = value; }
        public Panel PriceTblPnl { get => priceTblPnl; set => priceTblPnl = value; }
        public PictureBox ImageLbl { get => imageLbl; set => imageLbl = value; }
        public Label ServiceLbl1 { get => serviceLbl1; set => serviceLbl1 = value; }
        public Label ServiceLbl2 { get => serviceLbl2; set => serviceLbl2 = value; }
        public Label ServiceLbl3 { get => serviceLbl3; set => serviceLbl3 = value; }
        public Label ServiceLbl4 { get => serviceLbl4; set => serviceLbl4 = value; }
        public Label ServiceLbl5 { get => serviceLbl5; set => serviceLbl5 = value; }
        public Label ServiceLbl6 { get => serviceLbl6; set => serviceLbl6 = value; }
        public Label ServiceLbl7 { get => serviceLbl7; set => serviceLbl7 = value; }
        public Label ServiceLbl8 { get => serviceLbl8; set => serviceLbl8 = value; }
        public Panel ScrollServiceList { get => scrollServiceList; set => scrollServiceList = value; }
        public Button ThuephongBtn { get => thuephongBtn; set => thuephongBtn = value; }
    }
}