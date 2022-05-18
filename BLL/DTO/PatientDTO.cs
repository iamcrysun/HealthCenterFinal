using BLL.Operations;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTO
{
    public class PatientDTO // пациент
    {
        public string FullName { get; set; }
        public string Male { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public string PlaceOfWork { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Document { get; set; }
        public bool Closed { get; set; }
        public string Email { get; set; }
        public int StreetId { get; set; }   
        public int PlaceOfSee { get; set; } // участок
        public List<DoProcDTO> DoProcs { get; set; }
        public  List<DoctorSeeDTO> DoctorSees { get; set; }
        public  List<RecordInPatientFileDTO> RecordInPatientFiles { get; set; }

        public PatientDTO (Patient patient)
        {
            FullName = patient.FullName;
            Male = patient.Male;
            Id = patient.Id;
            Address = patient.Address;
            PlaceOfWork = patient.PlaceOfWork;
            DateOfBirth = patient.DateOfBirth;
            Document = patient.Document;
            Closed = patient.Closed;
            DoProcs = patient.DoProcs.Select(i => new DoProcDTO(i)).ToList();
            DoctorSees = patient.DoctorSees.Select(i => new DoctorSeeDTO(i)).ToList();
            RecordInPatientFiles = patient.RecordInPatientFiles.Select(i => new RecordInPatientFileDTO(i)).ToList();
            Email = patient.Email;
            StreetId = patient.StreetId;
            DBOperations db = new DBOperations();
            PlaceOfSee = db.GetStreet(patient.StreetId).PlaceOfSee;
            if (Email == null)
            {
                Email = "";
            }
        }
    }
}
