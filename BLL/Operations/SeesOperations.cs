using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operations
{
    public class SeesOperations // операции с записями на прием
    {
        DBOperations db = new DBOperations();
        public void Delete(DoctorSeeDTO see) // пациент не явился на прием
        {
            see.Closed = true;
            see.Visited = false;
            db.UpdateDoctorSee(see);
        }

        public void Post(RecordInPatientFileDTO record, int id) // проведен прием
        {
            var patient = db.GetPatient(record.PatientId);
            if (patient != null)
            {
                record.Date = DateTime.Now; // добавление к строке карты даты приема
                db.AddRecordInPatientFile(record); // добавление в базу строки приема
                Email.Priem(record, patient.Email); // отправка результатов приема на почту
            }
            var see = db.GetDoctorSee(id);
            if (see != null) // закрытие талона
            {
                see.Closed = true;
                see.Visited = true;
                db.UpdateDoctorSee(see);
            }
        }
    }
}
