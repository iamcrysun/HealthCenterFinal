using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Street
    {
        public Street()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Street1 { get; set; }
        public int PlaceOfSee { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
