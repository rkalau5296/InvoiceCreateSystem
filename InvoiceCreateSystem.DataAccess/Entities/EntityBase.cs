﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceCreateSystem.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
