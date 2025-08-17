using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.ApplicationServices.Mail;

public interface IEmailSender
{
    Task SendProductCreatedEmailAsync(string toEmail, string productName);
}