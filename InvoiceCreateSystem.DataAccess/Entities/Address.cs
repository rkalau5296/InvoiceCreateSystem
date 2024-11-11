using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Address : EntityBase
    {
        public Address()
        {
            Clients = new Collection<Client>();
        }
        
        [Required]
        [Display(Name = "Ulica")]
        [MaxLength(255)]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Numer")]
        [MaxLength(255)]
        public string Number { get; set; }
        [Required]
        [Display(Name = "Miejscowość")]
        [MaxLength(255)]
        public string City { get; set; }
        [Required]
        [Display(Name = "kod pocztowy")]
        [MaxLength(255)]
        public string PostalCode { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}