using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTO
{
    public class ScheduleProcedureDTO // запись в расписании о процедуре, не используется в базовой версии
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public int DayId { get; set; }
        public int ProcedureId { get; set; }
        public int Count { get; set; }
        public bool Closed { get; set; }

        public DayDTO Day { get; set; }
        public TypeofProcDTO Procedure { get; set; }
        public List<ProcedureDTO> Procedures { get; set; }

        public ScheduleProcedureDTO (ScheduleProcedure scheduleProcedure)
        {
            Id = scheduleProcedure.Id;
            Room = scheduleProcedure.Room;
            DayId = scheduleProcedure.DayId;
            ProcedureId = scheduleProcedure.ProcedureId;
            Count = scheduleProcedure.Count;
            Closed = scheduleProcedure.Closed;
            Day = new DayDTO(scheduleProcedure.Day);
            Procedure = new TypeofProcDTO(scheduleProcedure.Procedure);
            Procedures = scheduleProcedure.Procedures.Select(i => new ProcedureDTO(i)).ToList();

        }
    }
}
