using Domain;
using Infrastructure;

namespace Application
{
    public class EmployeeService : IService<Employee>
    {
        public readonly IRepository<Employee> _employeeRepository;
        public  EmployeeService(IRepository<Employee> empRepo) 
        {
            _employeeRepository = empRepo;
        }

        public void Delete(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _employeeRepository.Remove(entity);
                    _employeeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee Get(int Id)
        {
            try
            {
                var obj = _employeeRepository.GetById(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var obj = _employeeRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _employeeRepository.Add(entity);
                    _employeeRepository.SaveChanges();
                }

            }catch (Exception)
            {
                throw;
            }
        }

        public void Update(Employee entity)
        {
            try
            {
                if (entity != null)
                {
                    _employeeRepository.Update(entity);
                    _employeeRepository.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
