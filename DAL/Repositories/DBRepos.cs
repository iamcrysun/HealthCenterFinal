using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class DBRepos : IDBRepos // репозиторий
    {
        private HealthyContext db;
        private DaysRepos daysRepos;
        private DoctorSeeRepos doctorSeeRepos;
        private DoctorRepos doctorRepos;
        private DoProcRepos doProcRepos;
        private PatientRepos patientRepos;
        private ProcedureRepos procedureRepos;
        private RecordInPatientFileRepos recordInPatientFileRepos;
        private ScheduleProcedureRepos scheduleProcedureRepos;
        private ScheduleRepos scheduleRepos;
        private SpecializationRepos specializationRepos;
        private TypeofProcRepos typeofProcRepos;
        private ShiftRepos shiftRepos;
        private StreetRepos streetRepos;



        public DBRepos()
        {
            db = new HealthyContext();
        }

        public IRepository<Day> Day
        {
            get
            {
                if (daysRepos == null)
                    daysRepos = new DaysRepos(db);
                return daysRepos;
            }
        }

        public IRepository<Shift> Shift
        {
            get
            {
                if (shiftRepos == null)
                    shiftRepos = new ShiftRepos(db);
                return shiftRepos;
            }
        }

        public IRepository<Street> Street
        {
            get
            {
                if (streetRepos == null)
                    streetRepos = new StreetRepos(db);
                return streetRepos;
            }
        }

        public IRepository<Doctor> Doctor
        {
            get
            {
                if (doctorRepos == null)
                    doctorRepos = new DoctorRepos(db);
                return doctorRepos;
            }
        }

        public IRepository<DoctorSee> DoctorSee
        {
            get
            {
                if (doctorSeeRepos == null)
                    doctorSeeRepos = new DoctorSeeRepos(db);
                return doctorSeeRepos;
            }
        }
        public IRepository<DoProc> DoProc
        {
            get
            {
                if (doProcRepos == null)
                    doProcRepos = new DoProcRepos(db);
                return doProcRepos;
            }
        }
        public IRepository<Patient> Patient
        {
            get
            {
                if (patientRepos == null)
                    patientRepos = new PatientRepos(db);
                return patientRepos;
            }
        }

        public IRepository<Procedure> Procedure
        {
            get
            {
                if (procedureRepos == null)
                    procedureRepos = new ProcedureRepos(db);
                return procedureRepos;
            }
        }

        public IRepository<RecordInPatientFile> RecordInPatientFile
        {
            get
            {
                if (recordInPatientFileRepos == null)
                    recordInPatientFileRepos = new RecordInPatientFileRepos(db);
                return recordInPatientFileRepos;
            }
        }
        public IRepository<Schedule> Schedule
        {
            get
            {
                if (scheduleRepos == null)
                    scheduleRepos = new ScheduleRepos(db);
                return scheduleRepos;
            }
        }
        public IRepository<ScheduleProcedure> ScheduleProcedure
        {
            get
            {
                if (scheduleProcedureRepos == null)
                    scheduleProcedureRepos = new ScheduleProcedureRepos(db);
                return scheduleProcedureRepos;
            }
        }
        public IRepository<Specialization> Specialization
        {
            get
            {
                if (specializationRepos == null)
                    specializationRepos = new SpecializationRepos(db);
                return specializationRepos;
            }
        }
        public IRepository<TypeofProc> TypeofProc
        {
            get
            {
                if (typeofProcRepos == null)
                    typeofProcRepos = new TypeofProcRepos(db);
                return typeofProcRepos;
            }
        }
        public int Save() // сохранение изменений
        {
            return db.SaveChanges();
        }
    }
}
