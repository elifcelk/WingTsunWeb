using Domain.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public class Enums
    {
        public enum AnnouncementType
        {
            [Display(Name ="Seminer")]
            [Color("warning")]
            Seminer,
            [Display(Name = "Duyuru")]
            [Color("danger")]
            Duyuru,
            [Display(Name = "Bilgi")]
            [Color("info")]
            Bilgi,
        }
    }
}
