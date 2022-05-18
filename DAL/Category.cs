using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Category
    {
        public Category()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
