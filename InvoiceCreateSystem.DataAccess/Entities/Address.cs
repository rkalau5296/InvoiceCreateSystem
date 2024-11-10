using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Address
    {
        public Address()
        {
            Clients = new Collection<Client>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Numer")]
        public string Number { get; set; }
        [Required]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }
        [Required]
        [Display(Name = "kod pocztowy")]
        public string PostalCode { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}