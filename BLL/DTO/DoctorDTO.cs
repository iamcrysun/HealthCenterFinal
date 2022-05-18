using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTO
{
    public class DoctorDTO // врач
    {
        public int PlaceOfSee { get; set; } // участок
        public string FullName { get; set; }
        public int Id { get; set; }
        public bool Certificate { get; set; }
        public bool Closed { get; set; }
        public string Email { get; set; }
        public SpecializationDTO Specialization { get; set; }
        public List<DoctorSeeDTO> DoctorSees { get; set; }
        public List<ScheduleDTO> Schedules { get; set; }

        public DoctorDTO()
        {

        }
        public DoctorDTO(Doctor doctor)
        {
            PlaceOfSee = doctor.PlaceOfSee;
            FullName = doctor.FullName;
            Id = doctor.Id;
            Certificate = doctor.Certificate;
            Closed = doctor.Closed;
            Specialization = new SpecializationDTO(doctor.Specialization);
            DoctorSees = doctor.DoctorSees.Select(i => new DoctorSeeDTO(i)).ToList();
            Schedules = doctor.Schedules.Select(i => new ScheduleDTO(i)).ToList();
            Email = doctor.Email;
            if (Email == null)
            {
                Email = "";
            }
        }
    }
}
