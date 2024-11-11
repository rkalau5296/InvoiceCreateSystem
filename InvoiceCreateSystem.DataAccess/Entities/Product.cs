using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            InvoicePositions = new Collection<InvoicePosition>();
        }
        
        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal Value { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ICollection<InvoicePosition> InvoicePositions { get; set; }
    }
}