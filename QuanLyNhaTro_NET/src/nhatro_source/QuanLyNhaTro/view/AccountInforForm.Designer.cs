using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class AccountInforForm : Form
    {
        private Panel mainPanel;
        private Panel photoPanel;
        private Panel infoPanel;
        private Panel buttonPanel;
        private Label photoLabel;
        private Label nameLabel;
        private Button editButton;
        private Button saveButton;
        private TextBox emailTextBox;
        private TextBox nameTextBox;
        private TextBox cccdTextBox;
        private DateTimePicker birthDatePicker;
        private ComboBox genderComboBox;
        private TextBox phoneTextBox;
        private TextBox addressTextBox;

        private void InitializeComponent()
        {
            // Basic settings
            Text = "Thông tin tài khoản";
            Size = new Size(400, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Main panel
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.AutoScroll = true;

            // Photo and name section
            // Photo and name section
            photoPanel = new Panel();
            photoPanel.Dock = DockStyle.Top;
            photoPanel.Height = 160; // Tăng chiều cao để đủ hiển thị ảnh và tên
            photoPanel.Padding = new Padding(0, 0, 0, 10);

            // Photo label
            photoLabel = new Label();
            photoLabel.Image = Image.FromFile("D:\\MyProjects\\final_QuanLyNhaTro\\src\\resources\\user_icon.png");
            photoLabel.Image = new Bitmap(photoLabel.Image, new Size(100, 100));
            photoLabel.Size = new Size(100, 100);
            photoLabel.Location = new Point((photoPanel.Width - photoLabel.Width) / 2, 10); // Căn giữa ảnh
            photoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Name label
            nameLabel = new Label();
            nameLabel.Text = "Tên: [Tên]";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point((photoPanel.Width - nameLabel.PreferredWidth) / 2, photoLabel.Bottom + 10); // Căn giữa tên dưới ảnh

            // Add controls to the photo panel
            photoPanel.Controls.Add(photoLabel);
            photoPanel.Controls.Add(nameLabel);

            // Đặt sự kiện thay đổi kích thước để căn giữa khi thay đổi kích thước form
            photoPanel.Resize += (s, e) => {
                photoLabel.Location = new Point((photoPanel.Width - photoLabel.Width) / 2, 10);
                nameLabel.Location = new Point((photoPanel.Width - nameLabel.PreferredWidth) / 2, photoLabel.Bottom + 10);
            };


            // Info panel
            infoPanel = new Panel();
            infoPanel.Dock = DockStyle.Top;
            infoPanel.Height = 300;
            infoPanel.Padding = new Padding(0, 0, 0, 10);
            var layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.RowCount = 8;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.Controls.Add(new Label { Text = "Email:", TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
            layout.Controls.Add(emailTextBox = new TextBox { Width = 150 }, 1, 0);
            layout.Controls.Add(new Label { Text = "Họ và tên:", TextAlign = ContentAlignment.MiddleLeft }, 0, 1);
            layout.Controls.Add(nameTextBox = new TextBox { Width = 150 }, 1, 1);
            layout.Controls.Add(new Label { Text = "Căn cước:", TextAlign = ContentAlignment.MiddleLeft }, 0, 2);
            layout.Controls.Add(cccdTextBox = new TextBox { Width = 150 }, 1, 2);
            layout.Controls.Add(new Label { Text = "Ngày sinh:", TextAlign = ContentAlignment.MiddleLeft }, 0, 3);
            layout.Controls.Add(birthDatePicker = new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 150 }, 1, 3);
            layout.Controls.Add(new Label { Text = "Giới tính:", TextAlign = ContentAlignment.MiddleLeft }, 0, 4);
            layout.Controls.Add(genderComboBox = new ComboBox { Width = 150 }, 1, 4);
            genderComboBox.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            layout.Controls.Add(new Label { Text = "Số điện thoại:", TextAlign = ContentAlignment.MiddleLeft }, 0, 5);
            layout.Controls.Add(phoneTextBox = new TextBox { Width = 150 }, 1, 5);
            layout.Controls.Add(new Label { Text = "Địa chỉ:", TextAlign = ContentAlignment.MiddleLeft }, 0, 6);
            layout.Controls.Add(addressTextBox = new TextBox { Width = 150 }, 1, 6);
            infoPanel.Controls.Add(layout);

            // Button panel
            buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Top;
            buttonPanel.Height = 50;
            buttonPanel.Padding = new Padding(0, 10, 0, 0);
            editButton = new Button { Text = "Sửa", Width = 100, Height = 30 };
            saveButton = new Button { Text = "Lưu", Width = 100, Height = 30 };
            editButton.Location = new Point(50, 10); 
            saveButton.Location = new Point(180, 10); 
            buttonPanel.Controls.Add(editButton);
            buttonPanel.Controls.Add(saveButton);

            new AccountInfoController(this).Init();

            mainPanel.Controls.Add(buttonPanel);
            mainPanel.Controls.Add(infoPanel);
            mainPanel.Controls.Add(photoPanel);

            Controls.Add(mainPanel);
        }

        public Panel MainPanel { get => mainPanel; set => mainPanel = value; }
        public Panel PhotoPanel { get => photoPanel; set => photoPanel = value; }
        public Panel InfoPanel { get => infoPanel; set => infoPanel = value; }
        public Panel ButtonPanel { get => buttonPanel; set => buttonPanel = value; }
        public Label PhotoLabel { get => photoLabel; set => photoLabel = value; }
        public Label NameLabel { get => nameLabel; set => nameLabel = value; }
        public Button EditButton { get => editButton; set => editButton = value; }
        public Button SaveButton { get => saveButton; set => saveButton = value; }
        public TextBox EmailTextBox { get => emailTextBox; set => emailTextBox = value; }
        public TextBox NameTextBox { get => nameTextBox; set => nameTextBox = value; }
        public TextBox CccdTextBox { get => cccdTextBox; set => cccdTextBox = value; }
        public DateTimePicker BirthDatePicker { get => birthDatePicker; set => birthDatePicker = value; }
        public ComboBox GenderComboBox { get => genderComboBox; set => genderComboBox = value; }
        public TextBox PhoneTextBox { get => phoneTextBox; set => phoneTextBox = value; }
        public TextBox AddressTextBox { get => addressTextBox; set => addressTextBox = value; }


    }
}