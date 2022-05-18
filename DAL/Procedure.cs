using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Procedure
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Visited { get; set; }
        public int DoProcId { get; set; }
        public int ScheduleId { get; set; }

        public virtual DoProc DoProc { get; set; }
        public virtual ScheduleProcedure Schedule { get; set; }
    }
}
