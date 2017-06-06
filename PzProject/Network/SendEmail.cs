using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace PzProject.Network
{
    internal class SendEmail
    {
        private const string Password = "programowanie";
        private const string YourEmail = "programowaniezespoloweisi2@gmail.com";
        private  MailAddress fromAddress;
        private SmtpClient smtp;


        public SendEmail()
        {
            fromAddress = new MailAddress(YourEmail, "Kino");

            smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, Password)
            };
        }

        public async Task SendAsync(string email, string tytul, string tresc)
        {
            await Task.Run(() =>
            {
                Send(email, tytul, tresc);
            });
        }

        private void Send(string email, string tytul, string tresc)
        {
            try
            {
                var toAddress = new MailAddress(email, "Ktos");
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = tytul,
                    Body = tresc
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}