using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.DTOs.Announcement
{
    public class AnnouncementDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public short Type { get; set; }
        public string MainImage { get; set; }
    }
}
