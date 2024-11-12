using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            Invoices = new Collection<Invoice>();
            Clients = new Collection<Client>();
            Products = new Collection<Product>();
            MethodOfPayments = new Collection<MethodOfPayment>();
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
