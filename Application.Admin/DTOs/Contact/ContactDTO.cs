using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.DTOs.Contact
{
    public class ContactDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
    }
}
