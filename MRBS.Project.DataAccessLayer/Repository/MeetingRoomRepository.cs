using Microsoft.EntityFrameworkCore;
using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        protected readonly MeetingRoomDBContext _meetingRoomDBContext;
        public MeetingRoomRepository(MeetingRoomDBContext meetingRoomDBContext)
        {
            _meetingRoomDBContext = meetingRoomDBContext;
        }

        public async Task<MeetingRoom> AddMeetingRoomDetail(MeetingRoom meetingRoom)
        {
            _meetingRoomDBContext.MeetingRooms.Add(meetingRoom);
            await _meetingRoomDBContext.SaveChangesAsync();
            return meetingRoom;
        }

        public async Task<List<MeetingRoom>> GetAllDetails()
        {
            return await _meetingRoomDBContext.MeetingRooms.ToListAsync();
        }

        public async Task<MeetingRoom> GetMeetingRoomById(int id)
        {
            return await _meetingRoomDBContext.MeetingRooms.FindAsync(id);
        }

        public Task<IEnumerable<MeetingRoomViewModel>> GetMeetingRoomsByLocationId(int id)
        {
            var roomList =
                (from r in _meetingRoomDBContext.MeetingRooms
                 join l in _meetingRoomDBContext.Locations on r.LocationId equals l.LocationId
                 
                 where r.LocationId == id
                 select new MeetingRoomViewModel
                 {
                     RoomId = r.RoomId,                     
                     RoomName = r.RoomName
                   
                 }).ToList();

            return Task.FromResult<IEnumerable<MeetingRoomViewModel>>(roomList); ;
        }

        public async Task RemoveMeetingRoomDetail(int id)
        {
            var result = await GetMeetingRoomById(id);
            _meetingRoomDBContext.MeetingRooms.Remove(result);
            await _meetingRoomDBContext.SaveChangesAsync();
        }

        public async Task<MeetingRoom> UpdateMeetingRoomDetail(MeetingRoom meetingRoom)
        {
            _meetingRoomDBContext.Entry(meetingRoom).State = EntityState.Modified;
            await _meetingRoomDBContext.SaveChangesAsync();
            return meetingRoom;
        }
    }
}
