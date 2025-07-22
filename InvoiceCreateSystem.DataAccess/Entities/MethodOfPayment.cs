using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class MethodOfPayment : EntityBase
    {
        public MethodOfPayment()
        {
            Invoices = [];
        }       
        
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}