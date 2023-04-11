using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SchoolDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string InstructorName { get; set; }
        public string InstructorStatus { get; set; }
        public string InstructorResume { get; set; }
        public string MapLink { get; set; }
        public string TimeTable { get; set; }
    }
}
