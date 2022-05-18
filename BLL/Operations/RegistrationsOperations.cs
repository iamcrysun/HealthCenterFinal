using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class RegistrationsOperations // операции по записи на прием
    {
        DBOperations db = new DBOperations();

        public DoctorDTO GetDoctor(int id, string email) // получить врача указанной специальности для пациента
        {
            // получить аккаунт пациента по почте
            var patient = db.GetPatients().Where(i => i.Email == email).FirstOrDefault(); 
            if (patient == null)
            {
                return new DoctorDTO() { Id = -1 };
            }
            // получить доктора с участка пациента с нужной специальностью
            var doctor = db.GetDoctors().Where(i => i.Specialization.Id == id &&
            i.PlaceOfSee == patient.PlaceOfSee &&
            i.Closed == false).FirstOrDefault();
            return doctor == null ? new DoctorDTO() { Id = -1} : doctor;
        }

        public string GetDays(int id, string email) // получить дни, в которые у врача
            // специальности id на участке пациента с указанной почтой есть прием
        {
            // строка дней
            string Days = "";
            // пациент
            var patient = db.GetPatients().Where(i => i.Email == email).FirstOrDefault();
            if (patient == null)
            {
                return Days;
            }
            // нужный врач
            var doctor = db.GetDoctors().Where(i => i.PlaceOfSee == patient.PlaceOfSee && 
            i.Specialization.Id == id).FirstOrDefault();
            if (doctor != null)
            {
                // расписание врача
                var schedules = db.GetSchedules().Where(i => i.DoctorId == doctor.Id);
                foreach (ScheduleDTO sc in schedules)
                {
                    // запись дней
                    Days += sc.DayofWeekNavigation.DayOfWeek;
                }
            }
            return Days;
        }

        public List<string> GetTimes(int id, DateTime date) // получение возможного времени
            // для записи в указанную дату к указанному врачу
        {
            // доступное время
            List<string> times = new List<string>();
            var doctor = db.GetDoctor(id); // выбранный врач
            if (doctor != null)
            {
                // список записей к врачу
                List<DoctorSeeDTO> doctorSees = db.GetDoctorSees()
                    .Where(i => i.DoctorId == id).ToList();
                if (doctorSees != null)
                {
                    //отбор действительных записей
                    doctorSees = doctorSees.Where(i => (i.Visited == null ||
                    i.Visited == false) && i.DateTime.Date == date.Date)
                        .ToList();
                    // получение дня недели для выбранной даты
                    int fDay = ((int)date.Date.DayOfWeek + 6) % 7 + 1;
                    // расписание к которому относится прием в данный день
                    var schedule = db.GetSchedules().Where(i => i.DoctorId == id &&
                    i.DayofWeekNavigation.Id == fDay).FirstOrDefault();
                    if (schedule != null)
                    {
                        // смена
                        ShiftDTO shift = db.GetShift(schedule.Shift.Id);
                        if (shift != null)
                        {
                            // начало смены
                            int start = Int32.Parse(shift.TimeofBegin.TotalMinutes.ToString());
                            // конец смены
                            int end = Int32.Parse(shift.TimeofEnd.TotalMinutes.ToString());
                            // прием - 15 минут, перебор всех возможный времен от начала до конца приема
                            for (int i = start; i <= end - 15; i += 15)
                            {
                                // нет записи на данной время
                                if (doctorSees.Where(j => j.DateTime.TimeOfDay.TotalMinutes == i)
                                    .FirstOrDefault() == null)
                                {
                                    // день - сегодня
                                    if (date.Date == DateTime.Now.Date)
                                    {
                                        // проверка, что время начала приема еще не прошло
                                        if (DateTime.Now.TimeOfDay.TotalMinutes > i)
                                        {
                                            continue;
                                        }
                                    }
                                    // часы
                                    String h;
                                    if (i / 60 > 9)
                                    {
                                        h = (i / 60).ToString();
                                    }
                                    else
                                    {
                                        h = '0' + (i / 60).ToString();
                                    }
                                    // минуты
                                    String m;
                                    if (i % 60 > 9)
                                    {
                                        m = (i % 60).ToString();
                                    }
                                    else
                                    {
                                        m = '0' + (i % 60).ToString();
                                    }
                                    // "склеиваем" минуты и часы
                                    times.Add(h + ':' + m);
                                }
                            }
                        }
                    }
                }
            }
            return times;
        }
    }
}
