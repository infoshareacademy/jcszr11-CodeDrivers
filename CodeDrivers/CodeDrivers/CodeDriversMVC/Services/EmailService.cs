using MailKit.Net.Smtp;
using MimeKit;

namespace CodeDriversMVC.Services
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("CodeDrivers", "codedrivers@op.pl"));
            emailMessage.To.Add(new MailboxAddress("Customer", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.poczta.onet.pl", 587, false);
                await client.AuthenticateAsync("codedrivers@op.pl", "Idea123456!@!");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
