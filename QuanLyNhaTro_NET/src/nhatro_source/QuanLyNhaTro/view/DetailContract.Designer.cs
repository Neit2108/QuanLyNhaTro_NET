using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class DetailContract : Form
    {
        private Panel mainPnl;
        private Panel vietNamPnl;
        private Label titleLbl;
        private Label subTitleLbl;
        private Label contractNameLbl;
        private Label dayOfCreateLbl;
        private Panel contractPnl;
        private TextBox nameField_A;
        private TextBox cccdField_A;
        private TextBox addressField_A;
        private TextBox nameField_B;
        private TextBox cccdField_B;
        private TextBox addressField_B;
        private DataGridView priceListTable;

        private void InitializeComponent()
        {
            // Form setup
            this.Text = "Hợp Đồng Thuê Nhà Ở";
            this.Size = new Size(794, 1123); // A4 size
            this.StartPosition = FormStartPosition.CenterScreen;

            // Main panel
            mainPnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                RowStyles =
                {
                    new RowStyle(SizeType.AutoSize), // For vietNamPnl
                    new RowStyle(SizeType.Percent, 40), // For contractPnl
                    new RowStyle(SizeType.Percent, 40)  // For priceListTable
                }
            };
            // Vietnam section panel
            vietNamPnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150
            };

            // Title labels
            titleLbl = CreateLabel("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", new Font("Segoe UI", 18, FontStyle.Bold));
            subTitleLbl = CreateLabel("Độc lập - Tự do - Hạnh phúc", new Font("Segoe UI", 14, FontStyle.Italic));
            contractNameLbl = CreateLabel("HỢP ĐỒNG THUÊ NHÀ Ở", new Font("Segoe UI", 22, FontStyle.Bold));
            dayOfCreateLbl = CreateLabel("Hà Nội, ngày ... tháng ... năm ...", new Font("Segoe UI", 14, FontStyle.Bold));

            // Set label positions
            titleLbl.Location = new Point(0, 0);
            titleLbl.Size = new Size(754, 30);

            subTitleLbl.Location = new Point(0, 35);
            subTitleLbl.Size = new Size(754, 25);

            contractNameLbl.Location = new Point(0, 70);
            contractNameLbl.Size = new Size(754, 35);

            dayOfCreateLbl.Location = new Point(0, 110);
            dayOfCreateLbl.Size = new Size(754, 25);
            // Add controls to vietNamPnl
            vietNamPnl.Controls.AddRange(new Control[] { titleLbl, subTitleLbl, contractNameLbl, dayOfCreateLbl });

            // Contract information panel
            contractPnl = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };


            // Create contract info layout with proper spacing
            TableLayoutPanel contractLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 14, // Increased for all sections
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 30),
                    new ColumnStyle(SizeType.Percent, 70)
                },
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Initialize text fields
            nameField_A = CreateTextBox(false);
            cccdField_A = CreateTextBox(false);
            addressField_A = CreateTextBox(false);
            nameField_B = CreateTextBox(false);
            cccdField_B = CreateTextBox(false);
            addressField_B = CreateTextBox(false);

            // Add sections with proper headers
            int row = 0;

            // Section A
            AddSectionHeader(contractLayout, "BÊN CHO THUÊ (BÊN A)", row++);
            AddLabeledField(contractLayout, "Họ và tên:", nameField_A, row++);
            AddLabeledField(contractLayout, "CCCD/CMND:", cccdField_A, row++);
            AddLabeledField(contractLayout, "Địa chỉ thường trú:", addressField_A, row++);

            // Spacing
            AddEmptyRow(contractLayout, row++);

            // Section B
            AddSectionHeader(contractLayout, "BÊN THUÊ (BÊN B)", row++);
            AddLabeledField(contractLayout, "Họ và tên:", nameField_B, row++);
            AddLabeledField(contractLayout, "CCCD/CMND:", cccdField_B, row++);
            AddLabeledField(contractLayout, "Địa chỉ thường trú:", addressField_B, row++);

            contractPnl.Controls.Add(contractLayout);

            // Price list table
            priceListTable = new DataGridView
            {
                Dock = DockStyle.Fill,
                Height = 200,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGray,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                }
            };

            priceListTable.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Tên dịch vụ", Name = "Name", Width = 200 },
                new DataGridViewTextBoxColumn { HeaderText = "Giá (VNĐ)", Name = "Price", Width = 150 },
                new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", Name = "Note" }
            });

            // Initial service data
            string[,] priceData = new string[,]
            {
                { "Internet", "100.000", "Tính theo tháng" },
                { "Điện", "4.000", "Tính theo số" },
                { "Nước", "100.000", "Tính theo đầu người" },
                { "Đỗ xe", "50.000", "Tính theo số xe" },
                { "Thang máy", "100.000", "Tính theo phòng" },
                { "Vệ sinh", "10.000", "Tính theo đầu người" }
            };

            foreach (DataGridViewColumn col in priceListTable.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Add the initial data
            for (int i = 0; i < priceData.GetLength(0); i++)
            {
                priceListTable.Rows.Add(priceData[i, 0], priceData[i, 1], priceData[i, 2]);
            }

            // Add panels to form in correct order
            //mainPnl.Controls.Add(mainLayout);
            mainLayout.Controls.Add(vietNamPnl, 0, 0);
            mainLayout.Controls.Add(contractPnl, 0, 1);
            mainLayout.Controls.Add(priceListTable, 0, 2);

            mainPnl.Controls.Add(mainLayout);

            this.Controls.Add(mainPnl);
        }

        private void AddSectionHeader(TableLayoutPanel panel, string headerText, int row)
        {
            Label headerLabel = new Label
            {
                Text = headerText,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(headerLabel, 0, row);
            panel.SetColumnSpan(headerLabel, 2);
        }

        private void AddEmptyRow(TableLayoutPanel panel, int row)
        {
            Label emptyLabel = new Label
            {
                Text = "",
                Height = 10
            };
            panel.Controls.Add(emptyLabel, 0, row);
            panel.SetColumnSpan(emptyLabel, 2);
        }

        private Label CreateLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Margin = new Padding(3)
            };
        }

        private TextBox CreateTextBox(bool editable)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                ReadOnly = !editable,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = editable ? Color.White : SystemColors.Control,
                Margin = new Padding(3),
                Padding = new Padding(5)
            };
        }

        private void AddLabeledField(TableLayoutPanel panel, string labelText, TextBox textBox, int row)
        {
            Label label = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 11),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(3)
            };

            panel.Controls.Add(label, 0, row);
            panel.Controls.Add(textBox, 1, row);
        }

        // Public properties with XML documentation
        /// <summary>
        /// Gets the name field for Party A (Landlord)
        /// </summary>
        public TextBox NameField_A => nameField_A;

        /// <summary>
        /// Gets the ID card field for Party A (Landlord)
        /// </summary>
        public TextBox CccdField_A => cccdField_A;

        /// <summary>
        /// Gets the address field for Party A (Landlord)
        /// </summary>
        public TextBox AddressField_A => addressField_A;

        /// <summary>
        /// Gets the name field for Party B (Tenant)
        /// </summary>
        public TextBox NameField_B => nameField_B;

        /// <summary>
        /// Gets the ID card field for Party B (Tenant)
        /// </summary>
        public TextBox CccdField_B => cccdField_B;

        /// <summary>
        /// Gets the address field for Party B (Tenant)
        /// </summary>
        public TextBox AddressField_B => addressField_B;

        /// <summary>
        /// Gets the price list table control
        /// </summary>
        public DataGridView PriceListTable => priceListTable;

        /// <summary>
        /// Gets the date creation label
        /// </summary>
        public Label DayOfCreateLbl => dayOfCreateLbl;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Add any custom painting if needed
            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawRectangle(pen, mainPnl.ClientRectangle);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Any additional initialization when the form loads
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Clean up resources if needed
            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }
        }
    }
}