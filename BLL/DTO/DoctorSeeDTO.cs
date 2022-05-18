using BLL.Operations;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DoctorSeeDTO // запись к врачу
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? Visited { get; set; } // посещена или нет
        public int Id { get; set; }
        public bool Closed { get; set; }
        public string Name { get; set; } // имя пациента

        public DoctorSeeDTO()
        {

        }
        public DoctorSeeDTO(DoctorSee doctorsee)
        {
            if (doctorsee != null)
            {
                DBOperations db = new DBOperations();
                Id = doctorsee.Id;
                Visited = doctorsee.Visited;
                DateTime = doctorsee.DateTime;
                PatientId = doctorsee.PatientId;
                var patient = db.GetPatient(doctorsee.PatientId);
                if (patient != null)
                {
                    Name = patient.FullName;
                }
                DoctorId = doctorsee.DoctorId;
                Closed = doctorsee.Closed;
            }
        }
    }
}
