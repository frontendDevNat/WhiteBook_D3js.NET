﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WhiteBook.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        public string Descr { get; set; }

    }
}
