using InvoiceCreateSystem.DataAccess.Entities;
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

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Insert(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            entities.Update(entity);
            return context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
