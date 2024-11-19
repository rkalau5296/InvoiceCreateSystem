namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
    }
}
