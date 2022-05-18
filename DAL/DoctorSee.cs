using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class DoctorSee
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? Visited { get; set; }
        public int Id { get; set; }
        public int? ZamId { get; set; }
        public bool Closed { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
