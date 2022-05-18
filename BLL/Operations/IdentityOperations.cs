using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operations
{
    public class IdentityOperations // операции с аккаунтами
    {
        public void setDoctor(DoctorDTO doctor) // установить почту для врача
        {
            DBOperations dBOperations = new DBOperations();
            dBOperations.UpdateDoctor(doctor);
        }

        public void setPatient(PatientDTO patient) // установить почту для пациента
        {
            DBOperations dBOperations = new DBOperations();
            dBOperations.UpdatePatient(patient);
        }
    }
}
