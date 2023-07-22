﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Models.Video
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
