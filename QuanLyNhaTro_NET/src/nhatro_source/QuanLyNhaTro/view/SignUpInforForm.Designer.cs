using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    public partial class SignUpInforForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private TextBox cccdTextBox;
        private TextBox nameTextBox;
        private TextBox birthdayTextBox;
        private TextBox phoneNumberTextBox;
        private TextBox addressTextBox;
        private Label cccdLabel;
        private Label nameLabel;
        private Label birthdayLabel;
        private Label genderLabel;
        private Label phoneNumberLabel;
        private Label addressLabel;
        private ComboBox genderComboBox;
        private Button submitButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            tableLayout = new TableLayoutPanel();
            cccdLabel = new Label();
            cccdTextBox = new TextBox();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            birthdayLabel = new Label();
            birthdayTextBox = new TextBox();
            genderLabel = new Label();
            genderComboBox = new ComboBox();
            phoneNumberLabel = new Label();
            phoneNumberTextBox = new TextBox();
            addressLabel = new Label();
            addressTextBox = new TextBox();
            submitButton = new Button();
            mainPanel.SuspendLayout();
            tableLayout.SuspendLayout();
            SuspendLayout();

            // Set Label Texts
            cccdLabel.Text = "CCCD:";
            nameLabel.Text = "Họ và tên:";
            birthdayLabel.Text = "Ngày sinh:";
            genderLabel.Text = "Giới tính:";
            phoneNumberLabel.Text = "Số điện thoại:";
            addressLabel.Text = "Địa chỉ:";

            // mainPanel
            mainPanel.Controls.Add(tableLayout);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20);
            mainPanel.Size = new Size(400, 500);
            mainPanel.BackColor = Color.White;
            mainPanel.TabIndex = 0;

            cccdLabel.TextAlign = ContentAlignment.MiddleRight;
            nameLabel.TextAlign = ContentAlignment.MiddleRight;
            birthdayLabel.TextAlign = ContentAlignment.MiddleRight;
            genderLabel.TextAlign = ContentAlignment.MiddleRight;
            phoneNumberLabel.TextAlign = ContentAlignment.MiddleRight;
            addressLabel.TextAlign = ContentAlignment.MiddleRight;

            // Set common width for TextBoxes and ComboBox
            int commonWidth = 200;

            cccdTextBox.Width = commonWidth;
            nameTextBox.Width = commonWidth;
            birthdayTextBox.Width = commonWidth;
            genderComboBox.Width = commonWidth;
            phoneNumberTextBox.Width = commonWidth;
            addressTextBox.Width = commonWidth;

            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayout.Controls.Add(cccdLabel, 0, 0);
            tableLayout.Controls.Add(cccdTextBox, 1, 0);
            tableLayout.Controls.Add(nameLabel, 0, 1);
            tableLayout.Controls.Add(nameTextBox, 1, 1);
            tableLayout.Controls.Add(birthdayLabel, 0, 2);
            tableLayout.Controls.Add(birthdayTextBox, 1, 2);
            tableLayout.Controls.Add(genderLabel, 0, 3);
            tableLayout.Controls.Add(genderComboBox, 1, 3);
            tableLayout.Controls.Add(phoneNumberLabel, 0, 4);
            tableLayout.Controls.Add(phoneNumberTextBox, 1, 4);
            tableLayout.Controls.Add(addressLabel, 0, 5);
            tableLayout.Controls.Add(addressTextBox, 1, 5);
            tableLayout.Controls.Add(submitButton, 1, 6);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(20, 20);
            tableLayout.Name = "tableLayout";
            tableLayout.Padding = new Padding(10);
            tableLayout.RowCount = 7;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayout.Size = new Size(360, 450);
            tableLayout.TabIndex = 0;

            Label[] labels = { cccdLabel, nameLabel, birthdayLabel, genderLabel, phoneNumberLabel, addressLabel };
            foreach (var label in labels)
            {
                label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(51, 51, 51);
            }

            TextBox[] textBoxes = { cccdTextBox, nameTextBox, birthdayTextBox, phoneNumberTextBox, addressTextBox };
            foreach (var textBox in textBoxes)
            {
                textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                textBox.Padding = new Padding(10);
                textBox.BackColor = Color.FromArgb(240, 240, 240);
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }

            genderComboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            genderComboBox.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            submitButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            submitButton.BackColor = Color.FromArgb(0, 123, 255);
            submitButton.ForeColor = Color.White;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.Size = new Size(100, 40);
            submitButton.Text = "Submit";
            submitButton.MouseEnter += (sender, e) => submitButton.BackColor = Color.FromArgb(0, 105, 217);
            submitButton.MouseLeave += (sender, e) => submitButton.BackColor = Color.FromArgb(0, 123, 255);

            new SignUpInforController(this).Init();

            ClientSize = new Size(400, 500);
            Controls.Add(mainPanel);
            Name = "SignUpInforForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up Information";
            mainPanel.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayout;

        public TextBox CccdTextBox { get => cccdTextBox; set => cccdTextBox = value; }
        public TextBox NameTextBox { get => nameTextBox; set => nameTextBox = value; }
        public TextBox BirthdayTextBox { get => birthdayTextBox; set => birthdayTextBox = value; }
        public ComboBox GenderComboBox { get => genderComboBox; set => genderComboBox = value; }
        public TextBox PhoneNumberTextBox { get => phoneNumberTextBox; set => phoneNumberTextBox = value; }
        public TextBox AddressTextBox { get => addressTextBox; set => addressTextBox = value; }
        public Button SubmitButton { get => submitButton; set => submitButton = value; }
    }
}