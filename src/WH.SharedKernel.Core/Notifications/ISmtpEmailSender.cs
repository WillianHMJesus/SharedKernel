using System.Net;
using System.Net.Mail;

namespace WH.SharedKernel.Notifications;

public interface ISmtpEmailSender
{
    void Send(MailMessage message, string host, int port, NetworkCredential? credential = null);
}
