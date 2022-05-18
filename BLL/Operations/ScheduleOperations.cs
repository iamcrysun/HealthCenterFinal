using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class ScheduleOperations // операции для расписания
    {
        DBOperations db = new DBOperations();
        public void Delete (ScheduleDTO schedule) // удаление строки расписания
        {
            // определение непроведенных приемов к данной дате
            var Sees = db.GetDoctorSees().Where(i => (int)(i.DateTime.DayOfWeek + 6) % 7
            == schedule.DayofWeekNavigation.Id && (i.Visited == null || !i.Visited.Value)).ToList();
            // отмена приемов
            foreach (DoctorSeeDTO s in Sees)
            {
                s.Closed = true;
                s.Visited = false;
                db.UpdateDoctorSee(s);
                Email.Close(s); // отправка сообщения об отмене приема
            }
            // удаление строки расписания
            db.DeleteSchedule(schedule.Id);
        }

        public void Update(ScheduleDTO schedule) // обновление строки расписания
        {
            // получение списка затронутых приемов
            var Sees = db.GetDoctorSees().Where(i => (int)(i.DateTime.DayOfWeek + 7) 
            % 7 == schedule.DayofWeekNavigation.Id && i.Visited == false).ToList();
            var oldSchedule = db.GetSchedule(schedule.Id);
            // сменилась смена приема
            if (schedule.Shift.Id != oldSchedule.Shift.Id)
            {
                // разница во времени начала
                double raznica = schedule.Shift.TimeofBegin.TotalMinutes 
                    - oldSchedule.Shift.TimeofBegin.TotalMinutes;
                foreach (DoctorSeeDTO s in Sees)
                {
                    // применение разницы
                    s.DateTime = s.DateTime.AddMinutes(raznica);
                    db.UpdateDoctorSee(s);
                    var patient = db.GetPatient(s.PatientId);
                    if (patient != null)
                    {
                        // отправка нового талона на почту
                        Email.Reg(s, patient.Email);
                    }
                }
            }
            var old = oldSchedule.DayofWeekNavigation.Id;
            var present = schedule.DayofWeekNavigation.Id;
            // сменился день недели
            if (present != old)
            {
                // разница в днях в сторону увеличения
                int raznica = present > old? present - old : 7 - old + present;
                foreach (DoctorSeeDTO s in Sees)
                {
                    s.DateTime = s.DateTime.AddDays(raznica);
                    db.UpdateDoctorSee(s);
                    var patient = db.GetPatient(s.PatientId);
                    if (patient != null)
                    {
                        // отправка нового талона на почту
                        Email.Reg(s, patient.Email);
                    }
                }
            }
            db.UpdateSchedule(schedule);
        }
    }
}
