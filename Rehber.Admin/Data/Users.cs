using System;
using System.Collections.Generic;

namespace Rehber.Admin.Data
{
    public partial class Users
    {
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string ExtraInfo { get; set; }

        public virtual Units Unit { get; set; }
    }
}
