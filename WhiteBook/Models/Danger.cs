using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class Danger
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }
        
        public string Variable { get; set; }

        public List<DangerYear> DangerYears { get; set; }

        public Danger()
        {
            DangerYears = new List<DangerYear>();
        }


    }
}
