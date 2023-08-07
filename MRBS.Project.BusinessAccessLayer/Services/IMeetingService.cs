using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public interface IMeetingService 
    {
        Task<IEnumerable<MeetingsViewModel>> GetAllMeeting();
        Task<IEnumerable<ResponseMeetingsDetailsViewModel>> GetMeetingById(int id);
        Task<BookedNewMeetingViewModel> AddMeeting(BookedNewMeetingViewModel meeting);
       // Task<Meeting> GetMeetingById(int id);
        Task<string> UpdateMeetingl(BookedNewMeetingViewModel meeting);
        Task RemoveMeeting(int id);       
        Task<bool> CheckMeetingConflict(int meetingRoomId, DateTime startTime, DateTime endTime);
    }
}
