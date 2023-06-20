using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Employee : BaseEntity
    {
        [Key]
        public int EmpID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string EmpPhoto { get; set; }
        public DateTime Birthdate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public City city { get; set; }
        public Country country { get; set; }
        public State state { get; set; }

        [NotMapped]
        public IFormFile EmpFile { get; set; }

    }
}