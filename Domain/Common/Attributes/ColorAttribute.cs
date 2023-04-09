using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Attributes
{
    public class ColorAttribute: Attribute
    {
        public string Name { get; set; }
        public ColorAttribute(string name)
        {
            this.Name = name;
        }
    }
}
