
using System.Windows.Forms;
using QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.controller;
namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.view
{
    partial class SignInForm : Form
    {
        //public Label labelTitle { get; set; }
        //public Label labelEmail { get; set; }
        //public Label labelPassword { get; set; }
        //public TextBox textBoxEmail { get; set; }
        //public TextBox textBoxPassword { get; set; }
        //public Button buttonSignIn { get; set; }
        //public Panel panelLeft { get; set; }
        //public Label labelSignUpPrompt { get; set; }
        //public LinkLabel linkSignUp { get; set; }

        private Label labelTitle;
        private Label labelEmail;
        private Label labelPassword;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button buttonSignIn;
        private Panel panelLeft;
        private Label labelSignUpPrompt;
        private LinkLabel linkSignUp;

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

        // Getter và setter cho buttonSignIn
        public Button ButtonSignIn
        {
            get { return buttonSignIn; }
            set { buttonSignIn = value; }
        }

        // Getter và setter cho panelLeft
        public Panel PanelLeft
        {
            get { return panelLeft; }
            set { panelLeft = value; }
        }

        // Getter và setter cho labelSignUpPrompt
        public Label LabelSignUpPrompt
        {
            get { return labelSignUpPrompt; }
            set { labelSignUpPrompt = value; }
        }

        // Getter và setter cho linkSignUp
        public LinkLabel LinkSignUp
        {
            get { return linkSignUp; }
            set { linkSignUp = value; }
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelSignUpPrompt = new System.Windows.Forms.Label();
            this.linkSignUp = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();

            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(400, 50);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(150, 40);
            this.labelTitle.Text = "Đăng Nhập";

            this.labelEmail.Location = new System.Drawing.Point(350, 120);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(100, 25);
            this.labelEmail.Text = "Email";

            this.labelPassword.Location = new System.Drawing.Point(350, 170);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(100, 25);
            this.labelPassword.Text = "Mật Khẩu";

            this.textBoxEmail.Location = new System.Drawing.Point(450, 120);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(200, 27);

            this.textBoxPassword.Location = new System.Drawing.Point(450, 170);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(200, 27);

            this.buttonSignIn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSignIn.ForeColor = System.Drawing.Color.White;
            this.buttonSignIn.Location = new System.Drawing.Point(450, 220);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(200, 35);
            this.buttonSignIn.Text = "Đăng nhập";
            this.buttonSignIn.UseVisualStyleBackColor = false;

            this.panelLeft.BackColor = System.Drawing.Color.LightGreen;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 450);

            this.labelSignUpPrompt.Location = new System.Drawing.Point(300, 400);
            this.labelSignUpPrompt.Name = "labelSignUpPrompt";
            this.labelSignUpPrompt.Size = new System.Drawing.Size(200, 20);
            this.labelSignUpPrompt.Text = "Bạn chưa có tài khoản?";

            this.linkSignUp.Location = new System.Drawing.Point(500, 400);
            this.linkSignUp.Name = "linkSignUp";
            this.linkSignUp.Size = new System.Drawing.Size(100, 20);
            this.linkSignUp.TabStop = true;
            this.linkSignUp.Text = "Đăng ký";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.labelSignUpPrompt);
            this.Controls.Add(this.linkSignUp);
            this.Name = "SignInForm";
            this.Text = "Đăng Nhập";
            new SignInController(this).InitController();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}