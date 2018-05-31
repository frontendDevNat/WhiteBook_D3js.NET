using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }        

        public List<DangerYear> DangerYears { get; set; }

        public Year()
        {
            DangerYears = new List<DangerYear>();
        }


    }
}
