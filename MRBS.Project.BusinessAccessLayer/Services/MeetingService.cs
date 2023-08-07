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
    public class MeetingService : IMeetingService
    {
        protected readonly IMeetingRepository _meetingRepository;
        public MeetingService(IMeetingRepository meetingRepository )
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<BookedNewMeetingViewModel> AddMeeting(BookedNewMeetingViewModel meeting)
        {
            return await _meetingRepository.AddDetail(meeting);
        }

        public async Task<IEnumerable<MeetingsViewModel>> GetAllMeeting()
        {
            return await _meetingRepository.GetAllDetail();
        }

        public async Task<IEnumerable<ResponseMeetingsDetailsViewModel>> GetMeetingById(int id)
        {
           return await _meetingRepository.GetById( id );
        }

        public async Task RemoveMeeting(int id)
        {
             await _meetingRepository.RemoveDetail( id );
        }

        public async Task<string> UpdateMeetingl(BookedNewMeetingViewModel meeting)
        {
            return await _meetingRepository.UpdateDetail( meeting );
        }

      

        public async Task<bool> CheckMeetingConflict(int meetingRoomId, DateTime startTime, DateTime endTime)
        {
            return await _meetingRepository.CheckMeetingConflict(meetingRoomId, startTime, endTime);
        }
    }
}
