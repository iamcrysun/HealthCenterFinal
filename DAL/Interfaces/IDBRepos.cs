using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IDBRepos
    {
        IRepository<Day> Day { get; }
        IRepository<Street> Street { get; }
        IRepository<Doctor> Doctor { get; }
        IRepository<DoctorSee> DoctorSee { get; }
        IRepository<DoProc> DoProc { get; }
        IRepository<Patient> Patient { get; }
        IRepository<Procedure> Procedure { get; }
        IRepository<RecordInPatientFile> RecordInPatientFile { get; }
        IRepository<Schedule> Schedule { get; }
        IRepository<ScheduleProcedure> ScheduleProcedure { get; }
        IRepository<Specialization> Specialization { get; }
        IRepository<TypeofProc> TypeofProc { get; }
        IRepository<Shift> Shift { get; }

    }
}
