using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class RecordInPatientFile
    {
        public RecordInPatientFile()
        {
            DoProcs = new HashSet<DoProc>();
            Medicaments = new HashSet<Medicament>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string Diagnosis { get; set; }
        public int? DoctorId { get; set; }
        public int? NurseId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Nurce Nurse { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<DoProc> DoProcs { get; set; }
        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}
