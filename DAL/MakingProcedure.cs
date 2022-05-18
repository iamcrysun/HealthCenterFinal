using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class MakingProcedure
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public int NurceId { get; set; }

        public virtual Nurce Nurce { get; set; }
        public virtual TypeofProc Procedure { get; set; }
    }
}
