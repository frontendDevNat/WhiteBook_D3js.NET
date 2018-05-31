using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class TerroristAttack
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public DateTime Date { get; set; }

        public int VictimsQuantity { get; set; }

        public int InjuredQuantity { get; set; }

        public int? RadicalOrganizationId { get; set; }

        public RadicalOrganization RadicalOrganization { get; set; }

        public int? TerroristAttackTypeId { get; set; }

        public TerroristAttackType TerroristAttackType { get; set; }

        public int? GermanyCityId { get; set; }

        public GermanyCity GermanyCity { get; set; }
    }
}
