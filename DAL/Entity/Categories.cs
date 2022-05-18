using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class Categories // использовалось в лабораторных
    {
        public Categories()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int ID { get; set; }

        [Required]
        public string Category { get; set; }

       
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
