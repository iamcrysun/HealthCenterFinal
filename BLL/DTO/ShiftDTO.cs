using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ShiftDTO // смена
    {
        public int Id { get; set; }
        public int Number { get; set; } // номер смены
        public TimeSpan TimeofBegin { get; set; } // начало
        public TimeSpan TimeofEnd { get; set; } // конец

        public ShiftDTO(Shift shift)
        {
            if (shift != null)
            {
                Id = shift.Id;
                Number = shift.Number;
                TimeofBegin = shift.TimeofBegin;
                TimeofEnd = shift.TimeofEnd;
            }
        }
    }
}
