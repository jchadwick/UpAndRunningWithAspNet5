using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class ArchivedPostsSummary
    {
        public DateTime Date
        {
            get
            {
                return new DateTime(Year, Month, 1);
            }
        }

        public int Count { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
