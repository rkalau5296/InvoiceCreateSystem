using System.ComponentModel.DataAnnotations;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Invoices = [];
            Clients = [];
            Products = [];
            MethodOfPayments = [];
        }
        [Required]
        [Display(Name = "Imię")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        [MaxLength(255)]
        public string Password { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<MethodOfPayment> MethodOfPayments { get; set; }
    }
}
