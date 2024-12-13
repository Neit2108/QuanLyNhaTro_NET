using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class ContractForm : UserControl
    {
        private Panel buttonPanel;
        private Button addBtn;
        private Button deleteBtn;
        private Button editBtn;
        private Panel inputPanel;
        private TextBox mahdField;
        private TextBox maphongField;
        private TextBox makhachField;
        private TextBox tiencocField;
        private TextBox ngaythueField;
        private TextBox timeField;
        private TextBox ngaytaoField;
        private TextBox trangthaiField;
        private TextBox searchField;
        private Button searchBtn;
        private DataGridView mainTable;
        private Panel mainTablePanel;

        private void InitializeComponent()
        {
            this.MinimumSize = new Size(1346, 793);
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;

            // Create input panel
            inputPanel = CreateInputPanel();
            inputPanel.Location = new Point(10, 50);
            inputPanel.Size = new Size(320, 600);
            this.Controls.Add(inputPanel);

            // Create main table panel
            mainTablePanel = CreateMainTablePanel();
            mainTablePanel.Location = new Point(330, 10);
            mainTablePanel.Size = new Size(1000, 640);
            this.Controls.Add(mainTablePanel);

            // Create button panel
            buttonPanel = CreateButtonPanel();
            buttonPanel.Location = new Point(330, 660);
            buttonPanel.Size = new Size(1000, 60);
            this.Controls.Add(buttonPanel);
        }

        private Panel CreateInputPanel()
        {
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            TableLayoutPanel layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 8,
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 30),
                    new ColumnStyle(SizeType.Percent, 70)
                }
            };

            // Initialize text boxes
            mahdField = new TextBox { Dock = DockStyle.Fill };
            maphongField = new TextBox { Dock = DockStyle.Fill };
            makhachField = new TextBox { Dock = DockStyle.Fill };
            tiencocField = new TextBox { Dock = DockStyle.Fill };
            ngaythueField = new TextBox { Dock = DockStyle.Fill };
            timeField = new TextBox { Dock = DockStyle.Fill };
            ngaytaoField = new TextBox { Dock = DockStyle.Fill };
            trangthaiField = new TextBox { Dock = DockStyle.Fill };

            // Add controls to layout
            string[] labels = new string[]
            {
                "Mã hợp đồng:", "Mã phòng:", "Mã khách:", "Tiền cọc:",
                "Ngày thuê:", "Thời hạn hợp đồng:", "Ngày tạo:", "Trạng thái:"
            };
            TextBox[] fields = new TextBox[]
            {
                mahdField, maphongField, makhachField, tiencocField,
                ngaythueField, timeField, ngaytaoField, trangthaiField
            };

            for (int i = 0; i < labels.Length; i++)
            {
                layout.Controls.Add(new Label { Text = labels[i], Dock = DockStyle.Fill }, 0, i);
                layout.Controls.Add(fields[i], 1, i);
            }

            panel.Controls.Add(layout);
            return panel;
        }

        private Panel CreateButtonPanel()
        {
            Panel panel = new Panel();
            FlowLayoutPanel flowLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true
            };

            addBtn = new Button
            {
                Text = "Thêm",
                Size = new Size(100, 35),
                Margin = new Padding(10)
            };

            editBtn = new Button
            {
                Text = "Thay đổi",
                Size = new Size(100, 35),
                Margin = new Padding(10)
            };

            deleteBtn = new Button
            {
                Text = "Xóa",
                Size = new Size(100, 35),
                Margin = new Padding(10)
            };

            flowLayout.Controls.AddRange(new Control[] { addBtn, editBtn, deleteBtn });
            panel.Controls.Add(flowLayout);
            return panel;
        }

        //private Panel CreateMainTablePanel()
        //{
        //    Panel panel = new Panel();
        //    panel.BorderStyle = BorderStyle.FixedSingle;

        //    // Search panel
        //    Panel searchPanel = new Panel { Dock = DockStyle.Top, Height = 50 };
        //    searchField = new TextBox { Size = new Size(200, 25), Location = new Point(80, 12) };
        //    searchBtn = new Button { Text = "Tìm", Size = new Size(60, 25), Location = new Point(290, 10) };
        //    Label searchLabel = new Label { Text = "Tìm kiếm:", Location = new Point(10, 15) };

        //    searchPanel.Controls.AddRange(new Control[] { searchLabel, searchField, searchBtn });
        //    panel.Controls.Add(searchPanel);

        //    // Main table
        //    mainTable = new DataGridView
        //    {
        //        Dock = DockStyle.Fill,
        //        AllowUserToAddRows = false,
        //        AllowUserToDeleteRows = false,
        //        ReadOnly = true,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        RowHeadersVisible = false,
        //        ColumnHeadersVisible = true,

        //        BackgroundColor = Color.White,
        //        AllowUserToResizeColumns = false,
        //        AllowUserToResizeRows = false,
        //        ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        //    };

        //    // Add columns
        //    mainTable.Columns.AddRange(new DataGridViewColumn[]
        //    {
        //        new DataGridViewTextBoxColumn { HeaderText = "Mã hợp đồng", Name = "MaHD" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Mã phòng", Name = "MaPhong" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Mã khách", Name = "MaKhach" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Tiền cọc", Name = "TienCoc" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Ngày thuê", Name = "NgayThue" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Thời hạn hợp đồng", Name = "ThoiHan" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Ngày tạo", Name = "NgayTao" },
        //        new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "TrangThai" }
        //    });

        //    panel.Controls.Add(mainTable);
        //    return panel;
        //}

        private Panel CreateMainTablePanel()
        {
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill
            };

            // Create TableLayoutPanel to manage layout
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                RowStyles =
        {
            new RowStyle(SizeType.Absolute, 50), // Search panel height
            new RowStyle(SizeType.Percent, 100)  // Table takes remaining space
        }
            };

            // Search panel
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 50
            };

            searchField = new TextBox
            {
                Size = new Size(200, 25),
                Location = new Point(80, 12)
            };

            searchBtn = new Button
            {
                Text = "Tìm",
                Size = new Size(60, 25),
                Location = new Point(290, 10)
            };

            Label searchLabel = new Label
            {
                Text = "Tìm kiếm:",
                Location = new Point(10, 15)
            };

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

            // Add columns
            mainTable.Columns.AddRange(new DataGridViewColumn[]
            {
        new DataGridViewTextBoxColumn { HeaderText = "Mã hợp đồng", Name = "MaHD" },
        new DataGridViewTextBoxColumn { HeaderText = "Mã phòng", Name = "MaPhong" },
        new DataGridViewTextBoxColumn { HeaderText = "Mã khách", Name = "MaKhach" },
        new DataGridViewTextBoxColumn { HeaderText = "Tiền cọc", Name = "TienCoc" },
        new DataGridViewTextBoxColumn { HeaderText = "Ngày thuê", Name = "NgayThue" },
        new DataGridViewTextBoxColumn { HeaderText = "Thời hạn hợp đồng", Name = "ThoiHan" },
        new DataGridViewTextBoxColumn { HeaderText = "Ngày tạo", Name = "NgayTao" },
        new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "TrangThai" }
            });

            // Style the column headers
            mainTable.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            mainTable.EnableHeadersVisualStyles = false;
            mainTable.ColumnHeadersHeight = 40;

            // Add controls to TableLayoutPanel
            tableLayout.Controls.Add(searchPanel, 0, 0);
            tableLayout.Controls.Add(mainTable, 0, 1);

            // Add TableLayoutPanel to main panel
            panel.Controls.Add(tableLayout);

            return panel;
        }

        // Public properties
        public Button AddBtn => addBtn;
        public Button DeleteBtn => deleteBtn;
        public Button EditBtn => editBtn;
        public TextBox MahdField => mahdField;
        public TextBox MaphongField => maphongField;
        public TextBox MakhachField => makhachField;
        public TextBox TiencocField => tiencocField;
        public TextBox NgaythueField => ngaythueField;
        public TextBox TimeField => timeField;
        public TextBox NgaytaoField => ngaytaoField;
        public TextBox TrangthaiField => trangthaiField;
        public TextBox SearchField => searchField;
        public Button SearchBtn => searchBtn;
        public DataGridView MainTable => mainTable;
    }
}