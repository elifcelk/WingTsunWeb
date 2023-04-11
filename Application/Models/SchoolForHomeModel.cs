using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SchoolForHomeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DistrictName { get; set; }
        public string PhotoPath { get; set; }
    }
}
