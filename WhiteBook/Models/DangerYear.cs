using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class DangerYear
    {
        public int DangerId { get; set; }

        public Danger Danger { get; set; }

        public int YearId { get; set; }

        public Year Year { get; set; }

        public float Amount { get; set; }

    }
}
