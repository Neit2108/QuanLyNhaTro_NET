using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class InvoiceForm : UserControl
    {
        private Panel mainTablePnl;
        private DataGridView mainTable;
        private TextBox searchField;
        private Button searchBtn;
        private Panel inputPanel;
        private TextBox numberField;
        private TextBox cccdField;
        private TextBox nameField;
        private TextBox dateField;
        private TextBox genderField;
        private TextBox phoneField;
        private TextBox addressField;
        private TextBox accountNumberField;
        private Button addBtn;
        private Button editBtn;
        private Button deleteBtn;
        private Button resetBtn;
        private Button autoAddBtn;

        private void InitializeComponents()
        {
            this.Size = new Size(1346, 793);

            Panel mainTablePanel = CreateMainTablePanel();
            mainTablePanel.Location = new Point(330, 10);
            mainTablePanel.Size = new Size(1000, 700);
            this.Controls.Add(mainTablePanel);

            Panel buttonPanel = CreateButtonPanel();
            buttonPanel.Location = new Point(10, 410);
            buttonPanel.Size = new Size(300, 100);
            this.Controls.Add(buttonPanel);

            Panel inputPanel = CreateInputPanel();
            inputPanel.Location = new Point(10, 50);
            inputPanel.Size = new Size(300, 350);
            this.Controls.Add(inputPanel);
        }

        private Panel CreateButtonPanel()
        {
            Panel panel = new Panel();
            panel.Padding = new Padding(10);

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            addBtn = new Button { Text = "Thêm", Size = new Size(80, 30), Margin = new Padding(5) };
            editBtn = new Button { Text = "Thay đổi", Size = new Size(80, 30), Margin = new Padding(5) };
            deleteBtn = new Button { Text = "Xóa", Size = new Size(80, 30), Margin = new Padding(5) };
            resetBtn = new Button { Text = "Làm mới", Size = new Size(80, 30), Margin = new Padding(5) };
            autoAddBtn = new Button { Text = "Tự động thêm", Size = new Size(100, 30), Margin = new Padding(5) };

            //flowPanel.Controls.Add(addBtn);
            flowPanel.Controls.Add(editBtn);
            flowPanel.Controls.Add(deleteBtn);
            flowPanel.Controls.Add(resetBtn);
            flowPanel.Controls.Add(autoAddBtn);

            panel.Controls.Add(flowPanel);
            return panel;
        }

        private Panel CreateInputPanel()
        {
            Panel panel = new Panel();
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(10)
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            panel.BorderStyle = BorderStyle.FixedSingle;

            // Create title for the panel
            Label titleLabel = new Label
            {
                Text = "Thông tin hóa đơn",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Height = 30
            };

            numberField = CreateTextField(false);
            cccdField = CreateTextField(true);
            nameField = CreateTextField(true);
            dateField = CreateTextField(true);
            genderField = CreateTextField(true);
            phoneField = CreateTextField(true);
            addressField = CreateTextField(true);
            accountNumberField = CreateTextField(true);

            AddFieldWithLabel(layout, "Mã khách:", numberField, 0);
            AddFieldWithLabel(layout, "CCCD:", cccdField, 1);
            AddFieldWithLabel(layout, "Tên khách:", nameField, 2);
            AddFieldWithLabel(layout, "Ngày sinh:", dateField, 3);
            AddFieldWithLabel(layout, "Giới tính:", genderField, 4);
            AddFieldWithLabel(layout, "Số điện thoại:", phoneField, 5);
            AddFieldWithLabel(layout, "Địa chỉ:", addressField, 6);
            AddFieldWithLabel(layout, "Mã tài khoản:", accountNumberField, 7);

            panel.Controls.Add(layout);
            panel.Controls.Add(titleLabel);

            return panel;
        }

        private Panel CreateMainTablePanel()
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Search panel
            Panel searchPanel = new Panel { Dock = DockStyle.Top, Height = 50 };
            searchField = new TextBox { Size = new Size(300, 25), Location = new Point(80, 12) };
            searchBtn = new Button { Text = "Tìm", Size = new Size(60, 25), Location = new Point(390, 10) };
            Label searchLabel = new Label { Text = "Tìm kiếm:", Location = new Point(10, 15) };

            searchPanel.Controls.AddRange(new Control[] { searchLabel, searchField, searchBtn });

            // Main table
            mainTable = new DataGridView
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
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersVisible = true // Explicitly set header visibility
            };

            mainTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            mainTable.EnableHeadersVisualStyles = false;
            mainTable.ColumnHeadersHeight = 40;

            mainTable.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Mã hóa đơn", Name = "MaHD" },
                new DataGridViewTextBoxColumn { HeaderText = "Mã Hợp Đồng", Name = "MaHopDong" },
                new DataGridViewTextBoxColumn { HeaderText = "Mã Phòng", Name = "MaPhong" },
                new DataGridViewTextBoxColumn { HeaderText = "Tổng Tiền", Name = "TongTien" },
                new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "TrangThai" },
                new DataGridViewTextBoxColumn { HeaderText = "Ngày Tạo", Name = "NgayTao" },
                new DataGridViewTextBoxColumn { HeaderText = "Ngày thanh toán", Name = "NgayThanhToan" }
            });

            panel.Controls.Add(mainTable);
            panel.Controls.Add(searchPanel);

            return panel;
        }

        private TextBox CreateTextField(bool editable)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Enabled = editable,
                Margin = new Padding(3)
            };
        }

        private void AddFieldWithLabel(TableLayoutPanel layout, string labelText, Control field, int row)
        {
            Label label = new Label
            {
                Text = labelText,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            layout.Controls.Add(label, 0, row);
            layout.Controls.Add(field, 1, row);
        }

        // Public properties
        public TextBox NumberField => numberField;
        public TextBox CccdField => cccdField;
        public TextBox NameField => nameField;
        public TextBox DateField => dateField;
        public TextBox GenderField => genderField;
        public TextBox PhoneField => phoneField;
        public TextBox AddressField => addressField;
        public TextBox AccountNumberField => accountNumberField;
        public DataGridView MainTable => mainTable;
        public TextBox SearchField => searchField;
        public Button SearchBtn => searchBtn;
        public Button AddBtn => addBtn;
        public Button EditBtn => editBtn;
        public Button DeleteBtn => deleteBtn;
        public Button ResetBtn => resetBtn;
        public Button AutoAddBtn => autoAddBtn;
    }
}