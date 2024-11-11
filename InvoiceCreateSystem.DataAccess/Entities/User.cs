using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class User : EntityBase
    {
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

    }
}
