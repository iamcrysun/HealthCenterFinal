using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class TypeofProc
    {
        public TypeofProc()
        {
            DoProcs = new HashSet<DoProc>();
            MakingProcedures = new HashSet<MakingProcedure>();
            ScheduleProcedures = new HashSet<ScheduleProcedure>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<DoProc> DoProcs { get; set; }
        public virtual ICollection<MakingProcedure> MakingProcedures { get; set; }
        public virtual ICollection<ScheduleProcedure> ScheduleProcedures { get; set; }
    }
}
