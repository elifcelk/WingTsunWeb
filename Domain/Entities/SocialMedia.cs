﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia :BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
    }
}
