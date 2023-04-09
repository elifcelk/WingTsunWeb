using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Application.Models
{
    public class AnnouncementDetailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string MainImage { get; set; }
        public AnnouncementType AnnouncementType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
