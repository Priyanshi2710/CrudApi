using Domain;
using Infrastructure;
using System.IO.Compression;
using System.Net;
using System.Reflection;

namespace Application
{
    public class EmployeeService : IService<Employee>, IService<EmployeeModel>
    {
        public readonly IRepository<Employee> _employeeRepository;
        

        public  EmployeeService(IRepository<Employee> empRepo) 
        {
            _employeeRepository = empRepo;
            
        }

        public void Insert(Employee entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
              EmployeeModel model = new EmployeeModel();
                Employee employee = new Employee()
                {
                    Firstname = model.Firstname,
                    Lastname=model.Lastname,
                    Email =model.Email,
                   Gender = model.Gender,
                   MaritalStatus=model.MaritalStatus,
                   Birthdate=model.Birthdate,
                   Salary=model.Salary,
                   Address=model.Address,
                   Password=model.Password,
                   CountryCode=model.CountryCode,
                     CityCode= model.CityCode,
                    StateCode=model.StateCode,
                    EmpPhoto = model.EmpFile.ToString(),

                };
                entity = employee;
                //Employee employee = new Employee();
                _employeeRepository.Add(entity);

                


                

            }
            throw new NotImplementedException();
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

        IEnumerable<EmployeeModel> IService<EmployeeModel>.GetAll()
        {
            throw new NotImplementedException();
        }

        EmployeeModel IService<EmployeeModel>.Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            else
            {
                EmployeeModel model = new EmployeeModel();
                Employee employee = new Employee()
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus,
                    Birthdate = model.Birthdate,
                    Salary = model.Salary,
                    Address = model.Address,
                    Password = model.Password,
                    CountryCode = model.CountryCode,
                    CityCode = model.CityCode,
                    StateCode = model.StateCode,
                    EmpPhoto = model.EmpFile.ToString(),

                };
                entity = employee;
                //Employee employee = new Employee();
                _employeeRepository.Add(entity);
            }
        }

        public void Update(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(EmployeeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
