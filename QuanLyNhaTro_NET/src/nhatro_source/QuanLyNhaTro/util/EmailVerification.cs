using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;


namespace QuanLyNhaTro_NET.src.nhatro_source.QuanLyNhaTro.util
{
    public class EmailVerification
    {
        private readonly string senderEmail;
        private readonly string senderPassword;
        private readonly string smtpHost;
        private readonly int smtpPort;

        public EmailVerification()
        {
            this.senderEmail = Constant.SenderMail;
            this.senderPassword = Constant.SenderPass;
            this.smtpHost = "smtp.gmail.com"; // Change if needed
            this.smtpPort = 587; // SMTP port
        }

        private string GenerateVerificationCode()
        {
            // Generate verification code
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0) % 1000000;
                return String.Format("{0:D6}", Math.Abs(value));
            }
        }

        public string SendVerificationEmail(string recipientEmail)
        {
            // Generate a random verification code
            string verificationCode = GenerateVerificationCode();

            // Email information
            var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            try
            {
                // Create a MailMessage object
                var message = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "Mã xác thực đăng ký",
                    Body = "Mã xác thực của bạn là: " + verificationCode
                };

                // Send email
                client.Send(message);
                Console.WriteLine("Email sent successfully to: " + recipientEmail);
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return verificationCode; // Return the verification code
        }
    }

}