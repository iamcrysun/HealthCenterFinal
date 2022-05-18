using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public static class Record
    {
        public static List<RecordInPatientFileDTO> Get(int id) // получить карту для пациента
        {
            DBOperations db = new DBOperations();
            return db.GetRecordInPatientFiles().Where(i => i.PatientId == id).ToList();
        }
    }
}
