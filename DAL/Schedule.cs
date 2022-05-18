using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int Room { get; set; }
        public int DayofWeek { get; set; }
        public int? ZamId { get; set; }
        public int ShiftId { get; set; }

        public virtual Day DayofWeekNavigation { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
