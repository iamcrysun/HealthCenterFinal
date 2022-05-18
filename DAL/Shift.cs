using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Shift
    {
        public Shift()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public TimeSpan TimeofBegin { get; set; }
        public TimeSpan TimeofEnd { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
