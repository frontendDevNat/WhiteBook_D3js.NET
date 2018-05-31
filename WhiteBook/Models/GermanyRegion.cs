using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class GermanyRegion
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        [MaxLength(2)]
        public string Code { get; set; }

        public ICollection<GermanyCity> GermanyCities { get; set; }

    }
}
