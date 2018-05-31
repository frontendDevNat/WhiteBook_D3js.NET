using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class Religion
    {
        public int Id { get; set; }

        public string Descr { get; set; }

        public ICollection<Confession> Confessions { get; set; }
    }
}
