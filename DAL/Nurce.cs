using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Nurce
    {
        public Nurce()
        {
            MakingProcedures = new HashSet<MakingProcedure>();
            RecordInPatientFiles = new HashSet<RecordInPatientFile>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int WorkEx { get; set; }
        public bool Closed { get; set; }

        public virtual ICollection<MakingProcedure> MakingProcedures { get; set; }
        public virtual ICollection<RecordInPatientFile> RecordInPatientFiles { get; set; }
    }
}
