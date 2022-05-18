using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Doctor
    {
        public Doctor()
        {
            DoctorSees = new HashSet<DoctorSee>();
            RecordInPatientFiles = new HashSet<RecordInPatientFile>();
            Schedules = new HashSet<Schedule>();
            Users = new HashSet<User>();
        }

        public int PlaceOfSee { get; set; }
        public int SpecializationId { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime? ZamEnd { get; set; }
        public bool Certificate { get; set; }
        public DateTime? ZamStart { get; set; }
        public bool Closed { get; set; }
        public string Email { get; set; }

        public virtual Category Category { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<DoctorSee> DoctorSees { get; set; }
        public virtual ICollection<RecordInPatientFile> RecordInPatientFiles { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
