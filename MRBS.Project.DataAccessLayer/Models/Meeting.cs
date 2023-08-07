using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MRBS.Project.API.Models
{
    public partial class Meeting
    {
        public int MeetingId { get; set; }
        public string MeetingTitle { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public virtual MeetingRoom Room { get; set; } = null!;
       
        public virtual User User { get; set; } = null!;
    }
}
