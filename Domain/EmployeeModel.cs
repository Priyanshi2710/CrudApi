using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmployeeModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
        public int StateCode { get; set; }

        [NotMapped]
        public IFormFile EmpFile { get; set; }
        

    }
}
