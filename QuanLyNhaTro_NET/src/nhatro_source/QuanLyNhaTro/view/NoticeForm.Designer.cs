using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class NoticeForm : UserControl
    {
        private DataGridView table;
        private Button btnDeleteAll;

        private void InitializeComponent()
        {
            // Main control setup
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.MinimumSize = new Size(1346, 793);
            this.AutoSize = true;
            this.BackColor = Color.White;

            // Create center panel
            Panel centerPanel = new Panel
            {
                Location = new Point(193, 60),
                Size = new Size(960, 560),
                BackColor = Color.White
            };
            this.Controls.Add(centerPanel);

            // Create title label
            Label titleLabel = new Label
            {
                Text = "Thông báo chi tiết",
                Font = new Font("Arial", 23, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(300, 30),
                Location = new Point(340, 0)
            };
            centerPanel.Controls.Add(titleLabel);

            // Create DataGridView with resize prevention
            table = new DataGridView
            {
                Location = new Point(0, 55),
                Size = new Size(960, 505),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeRows = false,    // Prevent row resizing
                AllowUserToResizeColumns = false, // Prevent column resizing
                ReadOnly = true,
                RowHeadersVisible = false,
                Font = new Font("Arial", 16),
                RowTemplate = { Height = 35 },
                Dock = DockStyle.None
            };

            // Set up columns with resize prevention
            table.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ID",
                    Visible = false,
                    Resizable = DataGridViewTriState.False
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    Width = 50,
                    HeaderText = "STT",
                    Resizable = DataGridViewTriState.False
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "NoiDung",
                    HeaderText = "Nội dung",
                    Resizable = DataGridViewTriState.False
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "NgayNhan",
                    Width = 150,
                    HeaderText = "Ngày nhận",
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Resizable = DataGridViewTriState.False
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "DaXem",
                    Width = 80,
                    HeaderText = "Đã xem",
                    Resizable = DataGridViewTriState.False
                }
            });

            // Style the header with resize prevention
            table.EnableHeadersVisualStyles = false;
            table.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            table.ColumnHeadersHeight = 40;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Center align specific columns
            table.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            table.Columns["NgayNhan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Lock column widths
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; // Disable column sorting
            }

            // Create delete button
            btnDeleteAll = new Button
            {
                Text = "Xóa tất cả",
                Location = new Point(830, 10),
                Size = new Size(120, 30),
                Font = new Font("Arial", 12),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDeleteAll.FlatAppearance.BorderSize = 0;

            // Add controls to center panel
            centerPanel.Controls.Add(table);
            centerPanel.Controls.Add(btnDeleteAll);

            // Initialize controller
            var controller = new NoticeFormController(this);
            controller.Init();
        }

        // Public properties
        public DataGridView Table => table;
        public Button BtnDeleteAll => btnDeleteAll;
    }
}