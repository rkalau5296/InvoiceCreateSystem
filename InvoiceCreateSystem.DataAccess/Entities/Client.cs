using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Client : EntityBase
    {
        public Client()
        {
            Invoices = new Collection<Invoice>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Address Address { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public User User { get; set; }
    }
}