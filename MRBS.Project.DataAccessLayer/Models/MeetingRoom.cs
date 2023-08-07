using System;
using System.Collections.Generic;

namespace MRBS.Project.API.Models
{
    public partial class MeetingRoom
    {
        public MeetingRoom()
        {
            Meetings = new HashSet<Meeting>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int LocationId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
