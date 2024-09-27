using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookingApi.Services
{
    public class EmailService
    {
        private readonly string _smtpHost = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "villabetimavrovo@gmail.com"; // Your Gmail address
        private readonly string _smtpPassword = "qybf yryd lsuv mcqa"; // Use the generated App Password

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient(_smtpHost)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUser, _smtpPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUser),
                To = { email },
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}