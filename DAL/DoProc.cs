using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class DoProc
    {
        public DoProc()
        {
            Procedures = new HashSet<Procedure>();
        }

        public int Id { get; set; }
        public int ProcId { get; set; }
        public int RecordId { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual TypeofProc Proc { get; set; }
        public virtual RecordInPatientFile Record { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
