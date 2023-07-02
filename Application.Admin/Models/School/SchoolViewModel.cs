using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Models.School
{
    public class SchoolViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string PhotoPath { get; set; }
        public string InstructorName { get; set; }
    }
}
