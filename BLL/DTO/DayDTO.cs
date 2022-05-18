using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DayDTO // день недели
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }

        public DayDTO()
        { }
        public DayDTO(Day day)
        {
            if (day == null)
            {
                Id = 1;
            }
            else
            {
                Id = day.Id;
                DayOfWeek = day.DayOfWeek;
            }
        }
    }
}
