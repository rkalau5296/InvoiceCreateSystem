using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class MethodOfPayment : EntityBase
    {
        public MethodOfPayment()
        {
            Invoices = new Collection<Invoice>();
        }
       
        
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}