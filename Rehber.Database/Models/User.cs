using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Database.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string ExtraInfo { get; set; }

    }
}
