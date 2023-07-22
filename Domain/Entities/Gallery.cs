﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gallery : BaseEntity
    {
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }
    }
}
