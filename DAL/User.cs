using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? DoctorId { get; set; }
        public int UserType { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual UserType UserTypeNavigation { get; set; }
    }
}
