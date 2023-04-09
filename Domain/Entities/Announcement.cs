using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Announcement:BaseEntity
    {
        public string Title { get; set; }
        public string MainImage { get; set; }
        public AnnouncementType AnnouncementType { get; set; }
        public string Content { get; set; }
    }
}
