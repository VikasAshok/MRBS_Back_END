using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public interface IMeetingRoomService
    {
        Task<List<MeetingRoom>> GetAllDetails();
        Task<MeetingRoom> GetMeetingRoomById(int id);
        Task<MeetingRoom> AddMeetingRoomDetail(MeetingRoom meetingRoom);
        Task<MeetingRoom> UpdateMeetingRoomDetail(MeetingRoom meetingRoom);
        Task RemoveMeetingRoomDetail(int id);
        Task<IEnumerable<MeetingRoomViewModel>> GetMeetingRoomsByLocationId(int id);
    }
}
