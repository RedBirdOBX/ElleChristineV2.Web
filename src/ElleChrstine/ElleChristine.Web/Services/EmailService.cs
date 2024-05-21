using ElleChristine.Web.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ElleChristine.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _mailSender = string.Empty;
        private readonly string _mailSenderPwd = string.Empty;
        private readonly string _mailReceiver = string.Empty;

        public EmailService(IConfiguration configuration)
        {
            _mailSender = configuration["MailSettings:mailSender"];
            _mailSenderPwd = configuration["MailSettings:mailSenderPwd"];
            _mailReceiver = configuration["MailSettings:mailReceiver"];
        }

        public async void SendAsync(ContactFormInputModel input)
        {
            // rvagutterproemailrobot@gmail.com
            // Gutter20231212!

            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_mailSender, _mailSenderPwd);

                var from = new MailAddress(_mailSender, "RVA GutterPro Messenger");
                var to = new MailAddress(_mailReceiver);
                var cc = new MailAddress(input.Email);
                var bcc = new MailAddress("shane.fowlkes.70@gmail.com");

                using (var message = new MailMessage(from, to))
                {
                    message.CC.Add(cc);
                    message.Bcc.Add(bcc);
                    message.Subject = "RVA GP Contact Us Form Submission";
                    message.IsBodyHtml = true;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<h3>Contact Us Form Submission</h3>");
                    sb.AppendLine("<table style=\"border: 1px solid black; border-collapse: collapse; width:500px;\">");
                    sb.AppendLine(" <tr style=\"border-bottom: 1px solid #ddd;\">");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">Name</td>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">{input.Name}</td>");
                    sb.AppendLine(" </tr>");
                    sb.AppendLine(" <tr style=\"border-bottom: 1px solid #ddd;\">");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">Email</td>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">{input.Email}</td>");
                    sb.AppendLine(" </tr>");
                    sb.AppendLine(" <tr style=\"border-bottom: 1px solid #ddd;\">");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">Phone</td>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">{input.Phone}</td>");
                    sb.AppendLine(" </tr>");
                    sb.AppendLine(" <tr style=\"border-bottom: 1px solid #ddd;\">");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">Subject</td>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">{input.Subject}</td>");
                    sb.AppendLine(" </tr>");
                    sb.AppendLine(" <tr>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">Message</td>");
                    sb.AppendLine($"    <td style=\"padding: 10px;\">{input.Message}</td>");
                    sb.AppendLine(" </tr>");
                    sb.AppendLine("</table>");
                    sb.AppendLine("<p>&nbsp;</p>");
                    sb.AppendLine("<p>Thank you and we will be in touch shortly.</p>");

                    message.Body = sb.ToString();

                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
