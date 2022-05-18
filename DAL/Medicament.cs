using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Medicament
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public string Medicine { get; set; }

        public virtual RecordInPatientFile Record { get; set; }
    }
}
