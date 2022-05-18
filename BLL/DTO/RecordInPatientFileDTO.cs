using BLL.Operations;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTO
{
    public class RecordInPatientFileDTO // запись в карту
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; } // назначение
        public string Diagnosis { get; set; } // диагноз
        public int DoctorId { get; set; }

        public  DoctorDTO Doctor { get; set; }

        public RecordInPatientFileDTO()
        {
        }

        public RecordInPatientFileDTO (RecordInPatientFile recordInPatientFile)
        {
            Id = recordInPatientFile.Id;
            PatientId = recordInPatientFile.PatientId;
            Date = recordInPatientFile.Date;
            Result = recordInPatientFile.Result;
            Diagnosis = recordInPatientFile.Diagnosis;
            DoctorId = recordInPatientFile.DoctorId.Value;
            DBOperations db = new DBOperations();
            Doctor = db.GetDoctor(DoctorId);
        }
    }
}
