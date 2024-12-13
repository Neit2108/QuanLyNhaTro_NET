using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class DetailInvoiceForm : Form
    {
        private Panel mainPnl;
        private Label titleLbl;
        private Label addressLbl;
        private Label numberOfRoomLbl;
        private TextBox elecField;
        private TextBox waterField;
        private TextBox internetField;
        private TextBox vehicleField;
        private TextBox cleanField;
        private DataGridView usedServiceTbl;
        private Label elecLbl;
        private Label waterLbl;
        private Label internetLbl;
        private Label vehicleLbl;
        private Label cleanLbl;
        private TextBox totalField;
        private Label totalLbl;
        private Label numberOfMemberLbl;
        private TextBox numberOfMemberField;
        private ComboBox paymentCombo;
        private Label paymentLbl;
        private Panel paymentBtnPnl;
        private Button exportBtn;
        private Button payBtn;
        private Label currentDateLbl;
        private Label userLbl;

        

        private void UpdateDateTime()
        {
            currentDateLbl.Text = $"Ngày giờ: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void InitializeComponent()
        {
            mainPnl = new Panel();
            contentPanel = new Panel();
            usedServiceTbl = new DataGridView();
            bottomPanel = new Panel();
            bottomLayout = new TableLayoutPanel();
            totalLbl = new Label();
            totalField = new TextBox();
            paymentLbl = new Label();
            paymentCombo = new ComboBox();
            buttonPanel = new FlowLayoutPanel();
            infoPanel = new Panel();
            infoLayout = new TableLayoutPanel();
            headerPanel = new Panel();
            titleLbl = new Label();
            currentDateLbl = new Label();
            userLbl = new Label();
            mainPnl.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usedServiceTbl).BeginInit();
            bottomPanel.SuspendLayout();
            bottomLayout.SuspendLayout();
            infoPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPnl
            // 
            mainPnl.Controls.Add(contentPanel);
            mainPnl.Controls.Add(infoPanel);
            mainPnl.Controls.Add(headerPanel);
            mainPnl.Location = new Point(0, 0);
            mainPnl.Name = "mainPnl";
            mainPnl.Size = new Size(200, 100);
            mainPnl.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(usedServiceTbl);
            contentPanel.Controls.Add(bottomPanel);
            contentPanel.Location = new Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(200, 100);
            contentPanel.TabIndex = 0;
            // 
            // usedServiceTbl
            // 
            usedServiceTbl.ColumnHeadersHeight = 29;
            usedServiceTbl.Location = new Point(0, 0);
            usedServiceTbl.Name = "usedServiceTbl";
            usedServiceTbl.RowHeadersWidth = 51;
            usedServiceTbl.Size = new Size(240, 150);
            usedServiceTbl.TabIndex = 0;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(bottomLayout);
            bottomPanel.Location = new Point(0, 0);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(200, 100);
            bottomPanel.TabIndex = 1;
            // 
            // bottomLayout
            // 
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomLayout.Controls.Add(totalLbl, 0, 0);
            bottomLayout.Controls.Add(totalField, 1, 0);
            bottomLayout.Controls.Add(paymentLbl, 0, 1);
            bottomLayout.Controls.Add(paymentCombo, 1, 1);
            bottomLayout.Controls.Add(buttonPanel, 2, 0);
            bottomLayout.Location = new Point(0, 0);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            bottomLayout.Size = new Size(200, 100);
            bottomLayout.TabIndex = 0;
            // 
            // totalLbl
            // 
            totalLbl.Location = new Point(3, 0);
            totalLbl.Name = "totalLbl";
            totalLbl.Size = new Size(14, 20);
            totalLbl.TabIndex = 0;
            // 
            // totalField
            // 
            totalField.Location = new Point(23, 3);
            totalField.Name = "totalField";
            totalField.Size = new Size(14, 27);
            totalField.TabIndex = 1;
            // 
            // paymentLbl
            // 
            paymentLbl.Location = new Point(3, 20);
            paymentLbl.Name = "paymentLbl";
            paymentLbl.Size = new Size(14, 23);
            paymentLbl.TabIndex = 2;
            // 
            // paymentCombo
            // 
            paymentCombo.Items.AddRange(new object[] { "Chuyển khoản", "Tiền mặt", "Thẻ" });
            paymentCombo.Location = new Point(23, 23);
            paymentCombo.Name = "paymentCombo";
            paymentCombo.Size = new Size(14, 28);
            paymentCombo.TabIndex = 3;
            // 
            // buttonPanel
            // 
            buttonPanel.Location = new Point(43, 3);
            buttonPanel.Name = "buttonPanel";
            bottomLayout.SetRowSpan(buttonPanel, 2);
            buttonPanel.Size = new Size(154, 94);
            buttonPanel.TabIndex = 4;
            // 
            // infoPanel
            // 
            infoPanel.Controls.Add(infoLayout);
            infoPanel.Location = new Point(0, 0);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(200, 100);
            infoPanel.TabIndex = 1;
            // 
            // infoLayout
            // 
            infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            infoLayout.Location = new Point(0, 0);
            infoLayout.Name = "infoLayout";
            infoLayout.Size = new Size(200, 100);
            infoLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(titleLbl);
            headerPanel.Controls.Add(currentDateLbl);
            headerPanel.Controls.Add(userLbl);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(200, 100);
            headerPanel.TabIndex = 2;
            // 
            // titleLbl
            // 
            titleLbl.Location = new Point(0, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(100, 23);
            titleLbl.TabIndex = 0;
            // 
            // currentDateLbl
            // 
            currentDateLbl.Location = new Point(0, 0);
            currentDateLbl.Name = "currentDateLbl";
            currentDateLbl.Size = new Size(100, 23);
            currentDateLbl.TabIndex = 1;
            // 
            // userLbl
            // 
            userLbl.Location = new Point(0, 0);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(100, 23);
            userLbl.TabIndex = 2;
            // 
            // DetailInvoiceForm
            // 
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(882, 653);
            Controls.Add(mainPnl);
            Name = "DetailInvoiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi Tiết Hóa Đơn";
            mainPnl.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)usedServiceTbl).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            bottomLayout.PerformLayout();
            infoPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void CreateInfoField(TableLayoutPanel layout, string labelText, ref TextBox field, int row)
        {
            Label label = new Label
            {
                Text = labelText,
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            field = new TextBox
            {
                Width = 150,
                Font = new Font("Segoe UI", 10),
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            layout.Controls.Add(label, 0, row);
            layout.Controls.Add(field, 1, row);
        }

        private Button CreateStyledButton(string text, Color backColor)
        {
            Button btn = new Button
            {
                Text = text,
                BackColor = backColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 35),
                Margin = new Padding(5, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Panel contentPanel;
        private Panel bottomPanel;
        private TableLayoutPanel bottomLayout;
        private FlowLayoutPanel buttonPanel;
        private Panel infoPanel;
        private TableLayoutPanel infoLayout;
        private Panel headerPanel;

        //create getter setter for all components
        public Panel MainPnl { get => mainPnl; set => mainPnl = value; }
        public Label TitleLbl { get => titleLbl; set => titleLbl = value; }
        public Label AddressLbl { get => addressLbl; set => addressLbl = value; }
        public Label NumberOfRoomLbl { get => numberOfRoomLbl; set => numberOfRoomLbl = value; }
        public TextBox ElecField { get => elecField; set => elecField = value; }
        public TextBox WaterField { get => waterField; set => waterField = value; }
        public TextBox InternetField { get => internetField; set => internetField = value; }
        public TextBox VehicleField { get => vehicleField; set => vehicleField = value; }
        public TextBox CleanField { get => cleanField; set => cleanField = value; }
        public DataGridView UsedServiceTbl { get => usedServiceTbl; set => usedServiceTbl = value; }
        public Label ElecLbl { get => elecLbl; set => elecLbl = value; }
        public Label WaterLbl { get => waterLbl; set => waterLbl = value; }
        public Label InternetLbl { get => internetLbl; set => internetLbl = value; }
        public Label VehicleLbl { get => vehicleLbl; set => vehicleLbl = value; }
        public Label CleanLbl { get => cleanLbl; set => cleanLbl = value; }
        public TextBox TotalField { get => totalField; set => totalField = value; }
        public Label TotalLbl { get => totalLbl; set => totalLbl = value; }
        public Label NumberOfMemberLbl { get => numberOfMemberLbl; set => numberOfMemberLbl = value; }
        public TextBox NumberOfMemberField { get => numberOfMemberField; set => numberOfMemberField = value; }
        public ComboBox PaymentCombo { get => paymentCombo; set => paymentCombo = value; }
        public Label PaymentLbl { get => paymentLbl; set => paymentLbl = value; }
        public Panel PaymentBtnPnl { get => paymentBtnPnl; set => paymentBtnPnl = value; }
        public Button ExportBtn { get => exportBtn; set => exportBtn = value; }
        public Button PayBtn { get => payBtn; set => payBtn = value; }
        public Label CurrentDateLbl { get => currentDateLbl; set => currentDateLbl = value; }
        public Label UserLbl { get => userLbl; set => userLbl = value; }

    }
}