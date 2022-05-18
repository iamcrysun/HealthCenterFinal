using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        public string SpecializationName { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
