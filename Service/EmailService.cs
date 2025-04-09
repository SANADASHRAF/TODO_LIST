using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
namespace Service
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Support", "job11228899@gmail.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain") { Text = message };

                using var client = new SmtpClient();

                // الاتصال بخادم SMTP
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // المصادقة باستخدام البريد الإلكتروني وكلمة مرور التطبيق
                await client.AuthenticateAsync("job11228899@gmail.com", "ebdi yqzr neaq suxg");

                // إرسال البريد الإلكتروني
                await client.SendAsync(emailMessage);

                //  قطع الاتصال SmtpCommandException: 5.7.8 Username and Password not accepted. For more information, go to
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

    }
}
