﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPeopleCRUDWebAPI.Models
{
    public class People
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
