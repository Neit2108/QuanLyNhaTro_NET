using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;
using System.Windows.Forms;

namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class SignUpForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        // Đảm bảo không bị rò rỉ tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            labelTitle = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            labelConfirmPassword = new Label();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            buttonSignUp = new Button();
            panelLeft = new Panel();
            labelSignInPrompt = new Label();
            linkSignIn = new LinkLabel();
            SuspendLayout();
            
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(400, 50);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(150, 40);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Đăng Ký";
            
            labelEmail.Location = new Point(350, 120);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 25);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email";
            
            labelPassword.Location = new Point(350, 170);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 25);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Mật Khẩu";
            
            labelConfirmPassword.Location = new Point(350, 220);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(140, 25);
            labelConfirmPassword.TabIndex = 3;
            labelConfirmPassword.Text = "Nhập lại mật khẩu";
            
            textBoxEmail.Location = new Point(496, 120);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 27);
            textBoxEmail.TabIndex = 4;
             
            textBoxPassword.Location = new Point(496, 170);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 27);
            textBoxPassword.TabIndex = 5;
             
            textBoxConfirmPassword.Location = new Point(496, 220);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(200, 27);
            textBoxConfirmPassword.TabIndex = 6;
            
            buttonSignUp.BackColor = Color.CornflowerBlue;
            buttonSignUp.ForeColor = Color.White;
            buttonSignUp.Location = new Point(450, 270);
            buttonSignUp.Name = "buttonSignUp";
            buttonSignUp.Size = new Size(200, 35);
            buttonSignUp.TabIndex = 7;
            buttonSignUp.Text = "Đăng ký";
            buttonSignUp.UseVisualStyleBackColor = false;
            
            panelLeft.BackColor = Color.LightGreen;
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(300, 450);
            panelLeft.TabIndex = 8;
             
            labelSignInPrompt.Location = new Point(300, 350);
            labelSignInPrompt.Name = "labelSignInPrompt";
            labelSignInPrompt.Size = new Size(200, 20);
            labelSignInPrompt.TabIndex = 9;
            labelSignInPrompt.Text = "Bạn đã có tài khoản ?";
             
            linkSignIn.Location = new Point(500, 350);
            linkSignIn.Name = "linkSignIn";
            linkSignIn.Size = new Size(100, 20);
            linkSignIn.TabIndex = 10;
            linkSignIn.TabStop = true;
            linkSignIn.Text = "Đăng nhập";
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelTitle);
            Controls.Add(labelEmail);
            Controls.Add(labelPassword);
            Controls.Add(labelConfirmPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(buttonSignUp);
            Controls.Add(panelLeft);
            Controls.Add(labelSignInPrompt);
            Controls.Add(linkSignIn);
            Name = "SignUpForm";
            Text = "Đăng Ký";

            new SignUpController(this, new SignUpCode()).InitController();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //public Label labelTitle { get; set; }
        //public Label labelEmail { get; set; }
        //public Label labelPassword { get; set; }
        //public Label labelConfirmPassword { get; set; }
        //public TextBox textBoxEmail { get; set; }
        //public TextBox textBoxPassword { get; set; }
        //public TextBox textBoxConfirmPassword { get; set; }
        //public Button buttonSignUp { get; set; }
        //public Panel panelLeft { get; set; }
        //public Label labelSignInPrompt { get; set; }
        //public LinkLabel linkSignIn { get; set; }

        private Label labelTitle;
        private Label labelEmail;
        private Label labelPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonSignUp;
        private Panel panelLeft;
        private Label labelSignInPrompt;
        private LinkLabel linkSignIn;

        // Getter và setter cho labelTitle
        public Label LabelTitle
        {
            get { return labelTitle; }
            set { labelTitle = value; }
        }

        // Getter và setter cho labelEmail
        public Label LabelEmail
        {
            get { return labelEmail; }
            set { labelEmail = value; }
        }

        // Getter và setter cho labelPassword
        public Label LabelPassword
        {
            get { return labelPassword; }
            set { labelPassword = value; }
        }

        // Getter và setter cho labelConfirmPassword
        public Label LabelConfirmPassword
        {
            get { return labelConfirmPassword; }
            set { labelConfirmPassword = value; }
        }

        // Getter và setter cho textBoxEmail
        public TextBox TextBoxEmail
        {
            get { return textBoxEmail; }
            set { textBoxEmail = value; }
        }

        // Getter và setter cho textBoxPassword
        public TextBox TextBoxPassword
        {
            get { return textBoxPassword; }
            set { textBoxPassword = value; }
        }

        // Getter và setter cho textBoxConfirmPassword
        public TextBox TextBoxConfirmPassword
        {
            get { return textBoxConfirmPassword; }
            set { textBoxConfirmPassword = value; }
        }

        // Getter và setter cho buttonSignUp
        public Button ButtonSignUp
        {
            get { return buttonSignUp; }
            set { buttonSignUp = value; }
        }

        // Getter và setter cho panelLeft
        public Panel PanelLeft
        {
            get { return panelLeft; }
            set { panelLeft = value; }
        }

        // Getter và setter cho labelSignInPrompt
        public Label LabelSignInPrompt
        {
            get { return labelSignInPrompt; }
            set { labelSignInPrompt = value; }
        }

        // Getter và setter cho linkSignIn
        public LinkLabel LinkSignIn
        {
            get { return linkSignIn; }
            set { linkSignIn = value; }
        }
    }
}
