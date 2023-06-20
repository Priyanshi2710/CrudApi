using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Country:BaseEntity
    {
        [Key]
        public int CountryCode { get; set; }
        public string Countryname { get; set; }

      //  public ICollection<Employee> employees { get; set; }

    }
}
