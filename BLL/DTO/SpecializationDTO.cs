using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class SpecializationDTO // специализация врача
    {
        public string SpecializationName { get; set; }
        public int Id { get; set; }

        public SpecializationDTO (Specialization specialization)
        {
            Id = specialization.Id;
            SpecializationName = specialization.SpecializationName;
        }
    }
}
