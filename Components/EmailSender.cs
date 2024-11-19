
using System.Net.Mail;

namespace ArtStudioManager.Components
{
    public static class EmailSender
    {
        private static readonly string _userName = ""; //add in borealis username and password when testing
        private static readonly string _password = "";

        public static void SendEmails(
            ICollection<string> emailAddresses, string fromAddress, string fromAddressDisplayName, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_userName, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;
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
                message.Dispose();
            }

            client.Dispose();
        }
    }
}
