﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        public Invoice()
        {
            InvoicePositions = [];
        }

        [Required]
        [Display(Name = "Tytuł")]
        [MaxLength(255)]
        public string Title { get; set; }
        public decimal Value { get; set; }
        [Display(Name = "Metoda płatności")]
        public int MethodOfPaymentId { get; set; }
        [Display(Name = "Data płatności")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Data wystawienia faktury")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Uwagi")]
        public string Comments { get; set; }
        [Display(Name = "Klient")]
        public int ClientId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
        public ICollection<InvoicePosition> InvoicePositions { get; set; }
    }
}