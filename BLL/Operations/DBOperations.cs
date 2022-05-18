using BLL.DTO;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class DBOperations
    {
        ILogger logger;
        DBRepos db;
        public DBOperations()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            logger = loggerFactory.CreateLogger<DBOperations>();
            try
            {
                db = new DBRepos();
            }
            catch
            {
                logger.LogError("Ошибка подключения к базе");
            }
        }
        public List<ScheduleDTO> GetSchedules()
        {
            try
            {
                return db.Schedule.GetList().Select(i => new ScheduleDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения расписания");
                return new List<ScheduleDTO>();
            }
        }

        public ScheduleDTO GetSchedule(int id)
        {
            try
            {
                Schedule h = db.Schedule.GetItem(id);
                return h == null ? null : new ScheduleDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения строки расписания с номером " + id);
                return null;
            }
        }

        public int AddSchedule(ScheduleDTO Schedule)
        {
            Schedule newSchedule = new Schedule();
            newSchedule.Room = Schedule.Room;
            newSchedule.ShiftId = Schedule.Shift.Id;
            newSchedule.ZamId = -1;
            newSchedule.DoctorId = Schedule.DoctorId;
            newSchedule.DayofWeek = Schedule.DayofWeekNavigation.Id;
            try
            {
                db.Schedule.Create(newSchedule);
                db.Schedule.Save();
                return newSchedule.Id;
            }
            catch
            {
                logger.LogError("Ошибка добавления строки расписания");
                return -1;
            }
        }

        public void UpdateSchedule(ScheduleDTO Schedule)
        {
            try
            {
                Schedule updatedSchedule = db.Schedule.GetItem(Schedule.Id);
                updatedSchedule.Room = Schedule.Room;
                updatedSchedule.ShiftId = Schedule.Shift.Id;
                updatedSchedule.ZamId = -1;
                updatedSchedule.DoctorId = Schedule.DoctorId;
                updatedSchedule.DayofWeek = Schedule.DayofWeekNavigation.Id;
                db.Schedule.Update(updatedSchedule);
                db.Schedule.Save();
            }
            catch
            {
                logger.LogError("Ошибка обновления строки расписания с номером" + Schedule.Id);
            }
        }

        public void DeleteSchedule (int Id)
        {
            try
            {
                db.Schedule.Delete(Id);
                db.Save();
            }
            catch
            {
                logger.LogError("Ошибка удаления строки расписания с номером" + Id);
            }
        }

        public List<DoctorSeeDTO> GetDoctorSees()
        {
            try
            {
                return db.DoctorSee.GetList().Select(i => new DoctorSeeDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списка записей на прием");
                return new List<DoctorSeeDTO>();
            }
        }

        public DoctorSeeDTO GetDoctorSee(int id)
        {
            try
            {
                DoctorSee h = db.DoctorSee.GetItem(id);
                return h == null ? null : new DoctorSeeDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения записи на примем с номером " + id);
                return null;
            }
        }

        public int AddDoctorSee(DoctorSeeDTO DoctorSee)
        {
            try
            {
                DoctorSee newDoctorSee = new DoctorSee();
                newDoctorSee.Closed = false;
                newDoctorSee.DateTime = DoctorSee.DateTime;
                newDoctorSee.DoctorId = DoctorSee.DoctorId;
                newDoctorSee.PatientId = DoctorSee.PatientId;
                newDoctorSee.Visited = null;
                newDoctorSee.ZamId = -1;
                db.DoctorSee.Create(newDoctorSee);
                db.DoctorSee.Save();
                return newDoctorSee.Id;
            }
            catch
            {
                logger.LogError("Ошибка добавления записи на прием");
                return -1;
            }
        }

        public void UpdateDoctorSee(DoctorSeeDTO DoctorSee)
        {
            try
            {
                DoctorSee updatedDoctorSee = db.DoctorSee.GetItem(DoctorSee.Id);
                updatedDoctorSee.Closed = DoctorSee.Closed;
                updatedDoctorSee.DateTime = DoctorSee.DateTime;
                updatedDoctorSee.DoctorId = DoctorSee.DoctorId;
                updatedDoctorSee.PatientId = DoctorSee.PatientId;
                updatedDoctorSee.Visited = DoctorSee.Visited;
                updatedDoctorSee.ZamId = -1;
                db.DoctorSee.Update(updatedDoctorSee);
                db.DoctorSee.Save();
            }
            catch
            {
                logger.LogError("Ошибка обновления записи к врачу с номером " + DoctorSee.Id);
            }
        }
         //CRUD Doctors
        public List<DoctorDTO> GetDoctors()
        {
            try
            {
                return db.Doctor.GetList().Select(i => new DoctorDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списка докторов");
                return new List<DoctorDTO>();
            }
        }

        public DoctorDTO GetDoctor(int id)
        {
            try
            {
                Doctor h = db.Doctor.GetItem(id);
                return h == null ? null : new DoctorDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения доктора с номером " + id);
                return null;
            }
        }

        public int AddDoctor(DoctorDTO Doctor)
        {
            try
            {
                Doctor newDoctor = new Doctor();
                newDoctor.Certificate = Doctor.Certificate;
                newDoctor.Closed = false;
                newDoctor.FullName = Doctor.FullName;
                newDoctor.PlaceOfSee = Doctor.PlaceOfSee;
                newDoctor.SpecializationId = Doctor.Specialization.Id;
                db.Doctor.Create(newDoctor);
                db.Doctor.Save();
                return newDoctor.Id;
            }
            catch
            {
                logger.LogError("Ошибка добавления доктора");
                return -1;
            }
        }

        public void UpdateDoctor(DoctorDTO Doctor)
        {
            try
            {
                Doctor updatedDoctor = db.Doctor.GetItem(Doctor.Id);
                updatedDoctor.Certificate = Doctor.Certificate;
                updatedDoctor.Closed = false;
                updatedDoctor.FullName = Doctor.FullName;
                updatedDoctor.PlaceOfSee = Doctor.PlaceOfSee;
                updatedDoctor.SpecializationId = Doctor.Specialization.Id;
                updatedDoctor.Email = Doctor.Email;
                db.Doctor.Update(updatedDoctor);
                db.Doctor.Save();
            }
            catch
            {
                logger.LogError("Ошибка обновления доктора с номером " + Doctor.Id);
            }
        }

        public List<DayDTO> GetDays()
        {
            try
            {
                return db.Day.GetList().Select(i => new DayDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списка дней");
                return new List<DayDTO>();
            }
        }

        public DayDTO GetDay(int id)
        {
            try
            {
                Day h = db.Day.GetItem(id);
                return h == null ? null : new DayDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения дня с номером " + id);
                return null;
            }
        }

        public List<ShiftDTO> GetShifts()
        {
            try
            {
                return db.Shift.GetList().Select(i => new ShiftDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списка смен");
                return new List<ShiftDTO>();
            }
        }

        public ShiftDTO GetShift(int id)
        {
            try
            {
                Shift h = db.Shift.GetItem(id);
                return h == null ? null : new ShiftDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения смены с номером " + id);
                return null;
            }
        }

        public List<PatientDTO> GetPatients()
        {
            try
            {
                return db.Patient.GetList().Select(i => new PatientDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списков пациентов");
                return new List<PatientDTO>();
            }
        }

        public PatientDTO GetPatient(int id)
        {
            try
            {
                Patient h = db.Patient.GetItem(id);
                return h == null ? null : new PatientDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения пациента с номером " + id);
                return null;
            }
        }

        public int AddPatient(PatientDTO Patient)
        {
            try
            {
                Patient newPatient = new Patient();
                newPatient.Address = Patient.Address;
                newPatient.Closed = false;
                newPatient.DateOfBirth = Patient.DateOfBirth;
                newPatient.Document = Patient.Document;
                newPatient.Email = Patient.Email;
                newPatient.FullName = Patient.FullName;
                newPatient.Male = Patient.Male;
                newPatient.PlaceOfWork = Patient.PlaceOfWork;
                newPatient.StreetId = Patient.StreetId;
                db.Patient.Create(newPatient);
                db.Patient.Save();
                return newPatient.Id;
            }
            catch
            {
                logger.LogError("Ошибка добавления пациента");
                return -1;
            }
        }

        public void UpdatePatient(PatientDTO Patient)
        {
            try
            {
                Patient newPatient = new Patient();
                newPatient.Id = Patient.Id;
                newPatient.Address = Patient.Address;
                newPatient.Closed = Patient.Closed;
                newPatient.DateOfBirth = Patient.DateOfBirth;
                newPatient.Document = Patient.Document;
                newPatient.Email = Patient.Email;
                newPatient.FullName = Patient.FullName;
                newPatient.Male = Patient.Male;
                newPatient.PlaceOfWork = Patient.PlaceOfWork;
                newPatient.StreetId = Patient.StreetId;
                db.Patient.Update(newPatient);
                db.Patient.Save();
            }
            catch
            {
                logger.LogError("Ошибка обновления данных пациента с номером " + Patient.Id);
            }
        }

        public List<SpecializationDTO> GetSpecializations()
        {
            try
            {
                return db.Specialization.GetList().Select(i => new SpecializationDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения списка специализаций");
                return new List<SpecializationDTO>();
            }
        }

        public SpecializationDTO GetSpecialization(int id)
        {
            try
            {
                Specialization h = db.Specialization.GetItem(id);
                return h == null ? null : new SpecializationDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения специализации по номеру " + id);
                return null;
            }
        }

        public Street GetStreet(int id)
        {
            try
            {
                Street h = db.Street.GetItem(id);
                return h == null ? null : h;
            }
            catch
            {
                logger.LogError("Ошибка получения улицы с номером " + id);
                return null;
            }
        }
        public List<RecordInPatientFileDTO> GetRecordInPatientFiles()
        {
            try
            {
                var res = db.RecordInPatientFile.GetList();
                return res.Select(i => new RecordInPatientFileDTO(i)).ToList();
            }
            catch
            {
                logger.LogError("Ошибка получения записей в карты");
                return new List<RecordInPatientFileDTO>();
            }
        }

        public RecordInPatientFileDTO GetRecordInPatientFile(int id)
        {
            try
            {
                RecordInPatientFile h = db.RecordInPatientFile.GetItem(id);
                return h == null ? null : new RecordInPatientFileDTO(h);
            }
            catch
            {
                logger.LogError("Ошибка получения записи из карты с номером " + id);
                return null;
            }
        }

        public int AddRecordInPatientFile(RecordInPatientFileDTO record)
        {
            RecordInPatientFile r = new RecordInPatientFile();
            r.Date = record.Date;
            r.Diagnosis = record.Diagnosis;
            r.DoctorId = record.DoctorId;
            r.PatientId = record.PatientId;
            r.Result = record.Result;
            try
            {
                db.RecordInPatientFile.Create(r);
                db.RecordInPatientFile.Save();
                return r.Id;
            }
            catch
            {
                logger.LogError("Ошибка создания записи в карту пациента");
                return -1;
            }
        }
    }
}