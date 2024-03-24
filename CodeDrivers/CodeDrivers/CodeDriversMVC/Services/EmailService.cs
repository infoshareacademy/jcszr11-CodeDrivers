using CodeDriversMVC.Models;
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

        public static string GenerateEmailContent(ReservationResultModel reservation)
        {
            var message = "Witaj! \n" +
                          "Dziękujemy za rezerwację samochodu w CodeDrivers. Poniżej przesyłamy szczegóły Twojej rezerwacji. \n" +
                          $"Auto: {reservation.Brand} {reservation.Model} \n" +
                          $"Data odbioru: {reservation.ReservationFrom.ToShortDateString()} \n" +
                          $"Data zwrotu: {reservation.ReservationTo.ToShortDateString()} \n" +
                          $"Cena całkowita: {reservation.TotalReservationPrice} zł \n" +
                          "W razie pytań jesteśmy do Twoje dyspozycji pod numerem 999 666 222 lub e-mailem codedrivers@o2.pl. \n" +
                          "Pozdrawiamy \n" +
                          "Ekipa CodeDrivers";

            return message;
        }
    }
}
