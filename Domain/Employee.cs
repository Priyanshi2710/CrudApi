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

        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? EmpPhoto { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }

       
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
        public int StateCode { get; set; }

        [NotMapped]
        public IFormFile EmpFile { get; set; }

        public virtual Country Country{ get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }

    }
}