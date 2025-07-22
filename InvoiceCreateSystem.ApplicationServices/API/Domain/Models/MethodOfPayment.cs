namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Models
{
    public class MethodOfPayment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
