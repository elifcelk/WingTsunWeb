using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SocialMediaIndexModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
