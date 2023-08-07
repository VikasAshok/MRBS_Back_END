using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.ViewModel
{
    public class ResponseMeetingsDetailsViewModel
    {
        public int MeetingId { get; set; }
        public string MeetingTitle { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string UserName { get; set; }
    }
}
