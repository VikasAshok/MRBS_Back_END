using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<MeetingsViewModel>> GetAllDetail();
        Task<IEnumerable<ResponseMeetingsDetailsViewModel>> GetById(int id);     
        Task<BookedNewMeetingViewModel> AddDetail(BookedNewMeetingViewModel meeting);
        Task<string> UpdateDetail(BookedNewMeetingViewModel meeting);
        Task RemoveDetail(int id);       

        Task<bool> CheckMeetingConflict(int meetingRoomId, DateTime startTime, DateTime endTime);
    }
}
