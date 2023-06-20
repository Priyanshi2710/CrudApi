using AutoMapper;
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
        private readonly IMapper _mapper;

        public Repository(EmployeeContext employeeContext,IMapper mapper)
        {
            _employeeContext = employeeContext;
          //  entities = _employeeContext.Set<T>();
            _mapper = mapper;
        }

        public async void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _employeeContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           // var result = _employeeContext.Employees.ToList();
           // return (IEnumerable<T>)result;
           var emp = _employeeContext.Employees.Include(c=> c.City).Include(c => c.Country).Include(c=> c.State).ToList();

            return (IEnumerable<T>)emp.AsEnumerable();
        }

        public T GetById(int id)
        {
            //throw new ArgumentNullException("entity");
            return entities.Find(id);
            //return entities.SingleOrDefault(c => c.Id == id);
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
