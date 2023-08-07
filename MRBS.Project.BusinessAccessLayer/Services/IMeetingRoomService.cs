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
        Task<List<MeetingRoom>> GetAllDetail();
        Task<MeetingRoom> GetById(int id);
        Task<MeetingRoom> AddDetail(MeetingRoom meetingRoom);
        Task<MeetingRoom> UpdateDetail(MeetingRoom meetingRoom);
        Task RemoveDetail(int id);
        Task<IEnumerable<MeetingRoomViewModel>> GetByLocationId(int id);
    }
}
