using System.Net;
using System.Net.Mail;
using BlogApi.src.Models;
using Microsoft.Extensions.Options;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}

public class EmailSender(IOptions<EmailSettings> emailSettings) : IEmailSender
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient(_emailSettings.MailServer)
        {
            Port = _emailSettings.MailPort,
            Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password),
            EnableSsl = _emailSettings.UseSSL
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.Sender),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);
        return client.SendMailAsync(mailMessage);
    }
}
