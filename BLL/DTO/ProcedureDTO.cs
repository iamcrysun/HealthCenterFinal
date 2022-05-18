using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProcedureDTO // процедура, не используется в базовой версии
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? Visited { get; set; }
        public int DoProcId { get; set; }
        public int ScheduleId { get; set; }

        public virtual DoProcDTO DoProc { get; set; }
        public virtual ScheduleProcedureDTO Schedule { get; set; }

        public ProcedureDTO (Procedure procedure)
        {
            Id = procedure.Id;
            Date = procedure.Date;
            Visited = procedure.Visited;
            DoProcId = procedure.DoProcId;
            ScheduleId = procedure.ScheduleId;
            DoProc = new DoProcDTO(procedure.DoProc);
            Schedule = new ScheduleProcedureDTO(procedure.Schedule);
        }
    }
}
