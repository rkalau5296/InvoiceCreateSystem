﻿using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceCreateSystem.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly InvoiceContext context;
        private DbSet<T> entities;

        public Repository(InvoiceContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
