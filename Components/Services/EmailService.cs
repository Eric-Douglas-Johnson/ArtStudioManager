using System.Net;
using System.Net.Mail;

namespace ArtStudioManager.Components.Services
{
    public static class EmailService
    {
        public static void SendEmails(
            string host, int port, string username, string password, ICollection<string> emailAddresses,
            string fromAddress, string fromAddressDisplayName, string subject, string body)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            SmtpClient client = new SmtpClient(host, port);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);
            MailAddress from = new MailAddress(fromAddress, fromAddressDisplayName, System.Text.Encoding.UTF8);
            MailAddress to;
            MailMessage message;

            foreach (string emailAddress in emailAddresses)
            {
                to = new MailAddress(emailAddress);
                message = new MailMessage(from, to);
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Subject = subject;
                message.Body = body;
                client.Send(message);
                System.Diagnostics.Debug.WriteLine("email sent for " + to.Address);
                message.Dispose();
            }

            client.Dispose();
        }
    }
}
