﻿namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int UserId {  get; set; }
    }
}
