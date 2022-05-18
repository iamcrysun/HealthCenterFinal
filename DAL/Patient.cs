using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Patient
    {
        public Patient()
        {
            DoProcs = new HashSet<DoProc>();
            DoctorSees = new HashSet<DoctorSee>();
            RecordInPatientFiles = new HashSet<RecordInPatientFile>();
        }

        public string FullName { get; set; }
        public string Male { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public string PlaceOfWork { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Document { get; set; }
        public int StreetId { get; set; }
        public bool Closed { get; set; }
        public string Email { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<DoProc> DoProcs { get; set; }
        public virtual ICollection<DoctorSee> DoctorSees { get; set; }
        public virtual ICollection<RecordInPatientFile> RecordInPatientFiles { get; set; }
    }
}
