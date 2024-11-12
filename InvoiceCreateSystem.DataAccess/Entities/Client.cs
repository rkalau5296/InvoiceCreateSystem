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
                
        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(255)]
        public string Name { get; set; }
        public int AddressId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int InvoiceId { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}