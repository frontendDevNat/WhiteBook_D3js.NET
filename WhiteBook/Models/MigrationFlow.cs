using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class MigrationFlow
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTill { get; set; }

        public int Amount { get; set; }

        public int? RiskyLevelId { get; set; }

        public RiskyLevel RiskyLevel { get; set; }

        public int? GermanyCityId { get; set; }

        public GermanyCity GermanyCity { get; set; }
        
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public int? ConfessionId { get; set; }

        public Confession Confession { get; set; }

        public int? MigrationTypeId { get; set; }

        public MigrationType MigrationType { get; set; }

    }
}
