using System.Net;
using System.Net.Mail;
using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.Extensions.Options;

namespace InvoiceCreateSystem.ApplicationServices.Mail;

public class EmailSender : IEmailSender
{ 
    private readonly SmtpSettings _settings;

    public EmailSender(IOptions<SmtpSettings> options)
    {
        _settings = options.Value;
    }

    public async Task SendProductCreatedEmailAsync(string toEmail, string productName)
    {
        var mail = new MailMessage(_settings.User, toEmail)
        {
            Subject = "Nowy produkt dodany",
            Body = $"Produkt '{productName}' został pomyślnie dodany."
        };

        using var smtp = new SmtpClient(_settings.Host, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.User, _settings.Password),
            EnableSsl = _settings.EnableSsl
        };

        await smtp.SendMailAsync(mail);
    }
}