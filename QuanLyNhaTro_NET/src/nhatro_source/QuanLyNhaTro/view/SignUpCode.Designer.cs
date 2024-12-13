using System.Windows.Forms;
using System.Drawing;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class SignUpCode : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label labelTitle { get; set; }
        public Label labelInstruction { get; set; }
        public TextBox textBoxCode { get; set; }
        public Button buttonResend { get; set; }
        public Button buttonOK { get; set; }
        public Button buttonCancel { get; set; }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new Label();
            this.labelInstruction = new Label();
            this.textBoxCode = new TextBox();
            this.buttonResend = new Button();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
 
            this.ClientSize = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xác Thực Mã";
 
            this.labelTitle.Text = "Nhập mã xác thực";
            this.labelTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.labelTitle.Dock = DockStyle.Top;
            this.labelTitle.Height = 30;
 
            this.labelInstruction.Text = "Mã xác nhận được gửi về mail";
            this.labelInstruction.Font = new Font("Segoe UI", 9F);
            this.labelInstruction.TextAlign = ContentAlignment.MiddleCenter;
            this.labelInstruction.Dock = DockStyle.Top;
            this.labelInstruction.Height = 20;
 
            this.textBoxCode.Font = new Font("Segoe UI", 10F);
            this.textBoxCode.Size = new Size(200, 30);
            this.textBoxCode.Location = new Point(50, 60);

            this.buttonResend.Text = "Gửi lại mã";
            this.buttonResend.BackColor = Color.Green;
            this.buttonResend.ForeColor = Color.White;
            this.buttonResend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.buttonResend.Size = new Size(200, 30);
            this.buttonResend.Location = new Point(50, 100);

            this.buttonOK.Text = "OK";
            this.buttonOK.BackColor = Color.Green;
            this.buttonOK.ForeColor = Color.White;
            this.buttonOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.buttonOK.Size = new Size(90, 30);
            this.buttonOK.Location = new Point(50, 140);

            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.BackColor = Color.Red;
            this.buttonCancel.ForeColor = Color.White;
            this.buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.buttonCancel.Size = new Size(90, 30);
            this.buttonCancel.Location = new Point(160, 140);

            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.buttonResend);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
        }

        #endregion
    }
}
