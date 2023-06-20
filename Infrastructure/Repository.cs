using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EmployeeContext _employeeContext;
        private DbSet<T> entities;

        public Repository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            entities = _employeeContext.Set<T>();
        }

        public void Add(T entity)
        {
           if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
           entities.Add(entity);
            _employeeContext.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _employeeContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _employeeContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            SaveChanges();
            //_employeeContext.SaveChanges();
        }




    }
}
