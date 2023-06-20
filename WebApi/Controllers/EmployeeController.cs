using Application;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> service;
        private readonly EmployeeContext context;
        
        public EmployeeController(IService<Employee> empservice, EmployeeContext employee)
        {
            service = empservice;
            context = employee;

        }
        [HttpGet(nameof(GetAllEmployees))]
        public IActionResult GetAllEmployees()
        {
            var obj = service.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetEmployeeById))]
        public IActionResult GetEmployeeById(int Id)
        {
            var obj = service.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateEmployee))]
        public IActionResult CreateEmployee([FromForm] Employee employee)
        {
            if (employee != null)
            {
                var file = employee.EmpFile;
               if (file == null || file.Length == 0) 
                {
                    return BadRequest("Please send a photo");
                }
                else
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\Api\\EmployeeApi\\WebApi\\Image", fileName);
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {

                        //D:/Api/EmployeeApi/WebApi/Image
                        file.CopyTo(stream);
                        employee.EmpPhoto = stream.ToString();

                    }
                    service.Insert(employee);
                    return Ok("Created Successfully");

                }
                

                

               
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(DeleteEmployee))]
        public IActionResult DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                service.Delete(employee);
                return Ok("Employee is Deleted Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }

        }
        [HttpPost(nameof(UpdateEmployee))]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                service.Update(employee);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
