using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MRBS.Project.API.Models
{
    public partial class User
    {
        public User()
        {
            Meetings = new HashSet<Meeting>();
        }

        public int UserId { get; set; }

       
        public string Username { get; set; } = null!;

        
        public string Password { get; set; } = null!;

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
