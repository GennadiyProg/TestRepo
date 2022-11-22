using System;
using System.Collections.Generic;

namespace Lab4
{
    internal class Company
    {
        public ICollection<Worker> workers { get; set; }
        public string Name { get; set; }
        public int PeriodPerformanceReview { get; set; }
    }
}
