using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class CyberThreat
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public DateTime Date { get; set; }
        
        public int? RadicalOrganizationId { get; set; }

        public RadicalOrganization RadicalOrganization { get; set; }

        public int? RiskyLevelId { get; set; }

        public RiskyLevel RiskyLevel { get; set; }

        public int? CyberThreatTypeId { get; set; }

        public CyberThreatType CyberThreatType { get; set; }

        public int? CountrySourceId { get; set; }

        public Country CountrySource { get; set; }
    }
}
