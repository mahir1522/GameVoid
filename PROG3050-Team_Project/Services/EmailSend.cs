using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net;
using System.Net.Mail;

namespace PROG3050_Team_Project.Services
{
    public class EmailSend : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSend(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("mahirp1020@gmail.com", "qsnd luap mfcx dkzn");
                client.EnableSsl = true;

                try
                {
                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress("mahirp1020@gmail.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    };

                    message.To.Add(to);
                    await client.SendMailAsync(message);
                }
                catch (SmtpException smtpEx)
                {
                    // Log SMTP exception for debugging
                    Console.WriteLine($"SMTP Error: {smtpEx.Message}");
                    throw new Exception("Failed to send email. Please check your email address and try again."); // Throw a more user-friendly error
                }
                catch (Exception ex)
                {
                    // Log general exception for debugging
                    Console.WriteLine($"General Error: {ex.Message}");
                    throw new Exception("An error occurred while sending the email. Please try again later."); // General error message
                }
            }
        }
    }
}