using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Day
    {
        public Day()
        {
            ScheduleProcedures = new HashSet<ScheduleProcedure>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string DayOfWeek { get; set; }

        public virtual ICollection<ScheduleProcedure> ScheduleProcedures { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
