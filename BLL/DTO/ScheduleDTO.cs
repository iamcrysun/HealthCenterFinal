using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ScheduleDTO // элемент расписания
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int Room { get; set; } // кабинет
        public ShiftDTO Shift { get; set; } // смена
        public  DayDTO DayofWeekNavigation { get; set; } // день недели

        public ScheduleDTO()
        {
        }
        public ScheduleDTO(Schedule schedule)
        {
            DBRepos db = new DBRepos();
            if (schedule.DayofWeekNavigation == null)
                schedule.DayofWeekNavigation = db.Day.GetItem(schedule.DayofWeek);
            if (schedule.Shift == null)
                schedule.Shift = db.Shift.GetItem(schedule.ShiftId);
            Id = schedule.Id;
            DoctorId = schedule.DoctorId;
            Room = schedule.Room;
            DayofWeekNavigation = new DayDTO(schedule.DayofWeekNavigation);
            Shift = new ShiftDTO(schedule.Shift);
        }
        
    }
}
