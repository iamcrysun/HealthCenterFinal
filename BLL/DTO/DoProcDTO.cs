using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTO
{
    public class DoProcDTO // назначенная процедура, не используется в базовой версии
    {
        public int Id { get; set; }
        public int ProcId { get; set; }
        public int RecordId { get; set; }
        public int PatientId { get; set; }

        public  PatientDTO Patient { get; set; }
        public  TypeofProcDTO Proc { get; set; }
        public  RecordInPatientFileDTO Record { get; set; }
        public  List<ProcedureDTO> Procedures { get; set; }

        public DoProcDTO (DoProc doProc)
        {
            Id = doProc.Id;
            ProcId = doProc.ProcId;
            RecordId = doProc.RecordId;
            PatientId = doProc.PatientId;
            Patient = new PatientDTO(doProc.Patient);
            Proc = new TypeofProcDTO(doProc.Proc);
            Record = new RecordInPatientFileDTO(doProc.Record);
            Procedures = doProc.Procedures.Select(i => new ProcedureDTO(i)).ToList();
        }
    }
}
