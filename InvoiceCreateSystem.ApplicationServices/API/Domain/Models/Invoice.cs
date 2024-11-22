namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public int MethodOfPaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Comments { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
