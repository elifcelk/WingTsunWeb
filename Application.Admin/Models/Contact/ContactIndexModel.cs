using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Models.Contact
{
    public class ContactIndexModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
