using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class PoliticalPartiesMovement
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }
    }
}
