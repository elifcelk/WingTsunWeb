using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Video : BaseEntity
    {
        public string Path { get; set; }
        public bool IsActive { get; set; }
    }
}
