using System.Net;
using System.Net.Mail;

namespace WH.SharedKernel.Notifications;

public sealed class SmtpEmailSender : ISmtpEmailSender
{
    public void Send(MailMessage message, string host, int port, NetworkCredential? credential = null)
    {
        using SmtpClient smtpClient = new SmtpClient(host, port)
        {
            Credentials = credential,
            EnableSsl = true
        };

        smtpClient.Send(message);
    }
}
