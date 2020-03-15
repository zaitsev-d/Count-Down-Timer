using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDT.UI.Model
{
    public class Holiday
    {
        string Name { get; set; }
        public DateTime Date { get; set; }

        public Holiday(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}
