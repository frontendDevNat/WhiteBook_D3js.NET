﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteBook.Models
{
    public class RadicalOrganization
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }

        public int? ReligionId { get; set; }

        public Religion Religion { get; set; }

        public int? PoliticalPartiesMovementId { get; set; }

        public PoliticalPartiesMovement PoliticalPartiesMovement { get; set; }
    }
}
