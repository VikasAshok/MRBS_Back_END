using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MRBS.Project.API.Models
{
    public partial class Location
    {
        public Location()
        {
            MeetingRooms = new HashSet<MeetingRoom>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;   

        [JsonIgnore]
        public virtual ICollection<MeetingRoom> MeetingRooms { get; set; }
    }
}
