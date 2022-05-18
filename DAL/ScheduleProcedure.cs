using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class ScheduleProcedure
    {
        public ScheduleProcedure()
        {
            Procedures = new HashSet<Procedure>();
        }

        public int Id { get; set; }
        public int Room { get; set; }
        public int DayId { get; set; }
        public int ProcedureId { get; set; }
        public int Count { get; set; }
        public bool Closed { get; set; }

        public virtual Day Day { get; set; }
        public virtual TypeofProc Procedure { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
