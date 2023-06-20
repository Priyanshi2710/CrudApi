using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class State : BaseEntity
    {
        [Key]
        public int StateCode { get; set; }
        public string StateName { get; set; }
        //public ICollection<Employee> employees { get; set; }
    }
}
