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

        public async Task<MeetingRoom> AddDetail(MeetingRoom meetingRoom)
        {
           return await _meetingRoomRepository.AddDetail(meetingRoom);
        }

        public async Task<List<MeetingRoom>> GetAllDetail()
        {
            return await _meetingRoomRepository.GetAllDetail();
        }

        public async Task<MeetingRoom> GetById(int id)
        {
            return await _meetingRoomRepository.GetById(id);
        }

        public async Task<IEnumerable<MeetingRoomViewModel>> GetByLocationId(int id)
        {
            return await _meetingRoomRepository.GetByLocationId(id);
        }

        public async Task RemoveDetail(int id)
        {
            await _meetingRoomRepository.RemoveDetail(id);
        }

        public async Task<MeetingRoom> UpdateDetail(MeetingRoom meetingRoom)
        {
            return await _meetingRoomRepository.UpdateDetail(meetingRoom);
        }
    }
}
