using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TimesDTO // выбранное время приема
    {
        public int ID { get; set; } // номер доктора
        public DateTime date { get; set; } // дата и время приема
    }
}
