using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class GermanyCity
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public int? GermanyRegionId { get; set; }

        public GermanyRegion GermanyRegion { get; set; }

    }
}
