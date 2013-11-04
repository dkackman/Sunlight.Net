using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunlightAPI.Congress
{
    public class Results<T>
    {
        public List<T> results { get; set; }

        public int count { get; set; }

        public PageResult page { get; set; }
    }
}
