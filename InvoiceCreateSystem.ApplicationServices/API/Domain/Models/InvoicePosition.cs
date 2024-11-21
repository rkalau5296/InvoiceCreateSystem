namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Models
{
    public class InvoicePosition
    {
        public int Id { get; set; }
        public int Lp { get; set; }
        public int InvoiceId { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
