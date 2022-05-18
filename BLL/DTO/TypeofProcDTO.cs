using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TypeofProcDTO // тип процедуры, не используется в базовой версии
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public TypeofProcDTO (TypeofProc typeofProc)
        {
            Id = typeofProc.Id;
            Type = typeofProc.Type;
        }
    }
}
