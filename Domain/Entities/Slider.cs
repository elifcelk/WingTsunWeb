using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Slider :BaseEntity
    {
        public int? SliderOrder { get; set; }
        public string BackgroundImage { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string LinkTitle { get; set; }
        public string LinkUrl { get; set; }
        public string Lang { get; set; }
        public string ColorCode { get; set; }
    }
}
