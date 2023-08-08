using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.Repository;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        protected readonly IMeetingRoomRepository _meetingRoomRepository;
        public MeetingRoomService(IMeetingRoomRepository meetingRoomRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
        }

        public async Task<MeetingRoom> AddMeetingRoomDetail(MeetingRoom meetingRoom)
        {
           return await _meetingRoomRepository.AddMeetingRoomDetail(meetingRoom);
        }

        public async Task<List<MeetingRoom>> GetAllDetails()
        {
            return await _meetingRoomRepository.GetAllDetails();
        }

        public async Task<MeetingRoom> GetMeetingRoomById(int id)
        {
            return await _meetingRoomRepository.GetMeetingRoomById(id);
        }

        public async Task<IEnumerable<MeetingRoomViewModel>> GetMeetingRoomsByLocationId(int id)
        {
            return await _meetingRoomRepository.GetMeetingRoomsByLocationId(id);
        }

        public async Task RemoveMeetingRoomDetail(int id)
        {
            await _meetingRoomRepository.RemoveMeetingRoomDetail(id);
        }

        public async Task<MeetingRoom> UpdateMeetingRoomDetail(MeetingRoom meetingRoom)
        {
            return await _meetingRoomRepository.UpdateMeetingRoomDetail(meetingRoom);
        }
    }
}
