using System;
using System.Collections.Generic;

namespace Rehber.Admin.Data
{
    public partial class Units
    {
        public Units()
        {
            Users = new HashSet<Users>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
