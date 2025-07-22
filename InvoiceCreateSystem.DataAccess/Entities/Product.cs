using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            InvoicePositions = [];
        }
        
        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal Value { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }      
        public User User { get; set; }        
        public ICollection<InvoicePosition> InvoicePositions { get; set; }
    }
}