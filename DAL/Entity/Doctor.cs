using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class Doctor // использовалось в лабораторных
    {
        [Required]
        public string FullName { get; set; }

        public int ID { get; set; }

        public int CategoryID { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
