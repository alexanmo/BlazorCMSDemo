using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFood.Models
{
    public class SheetResponse
    {
        public string Range { get; set; }
        public string MajorDimension { get; set; }
        public IList<IList<string>> Values { get; set; }
    }
}
