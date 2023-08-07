using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        protected readonly MeetingRoomDBContext _meetingRoomDBContext;
        public MeetingRepository(MeetingRoomDBContext meetingRoomDBContext)
        {
            _meetingRoomDBContext = meetingRoomDBContext;
        }

        public async Task<BookedNewMeetingViewModel> AddDetail(BookedNewMeetingViewModel meeting)
        {
            var newMeeting = new Meeting
            {
                MeetingTitle = meeting.MeetingTitle,
                StartTime = meeting.StartTime,
                EndTime = meeting.EndTime,
                RoomId = meeting.RoomId,
                UserId = meeting.UserId   
            
            
            };

            // Call the stored procedure to add the new meeting
            await _meetingRoomDBContext.Database.ExecuteSqlRawAsync("EXEC AddNewMeeting @MeetingTitle, @StartTime, @EndTime, @RoomId, @UserId",new[]
                {
                new SqlParameter("@MeetingTitle", newMeeting.MeetingTitle),
                new SqlParameter("@StartTime", newMeeting.StartTime),
                new SqlParameter("@EndTime", newMeeting.EndTime),
                new SqlParameter("@RoomId", newMeeting.RoomId),
                new SqlParameter("@UserId", newMeeting.UserId)
                }
                );
             return meeting;
        }


    

        public async Task<IEnumerable<MeetingsViewModel>> GetAllDetail()
        {
            var meetingList = await _meetingRoomDBContext.MeetingsViewModels.FromSqlRaw("EXEC GetMeetingsForCurrentDate").ToListAsync();

            return meetingList.AsEnumerable();

        }

        
        public  async Task<IEnumerable<ResponseMeetingsDetailsViewModel>> GetById(int id)
        {
            var meetingList = await _meetingRoomDBContext.Meetings.
                            Include(x => x.Room)
                           .Where(x => x.MeetingId == id)
                           .Select(x => new ResponseMeetingsDetailsViewModel
                           {
                               // Map properties from Meeting model to MeetingsViewModel
                               MeetingId = x.MeetingId,
                               MeetingTitle = x.MeetingTitle,
                               StartTime = x.StartTime,
                               EndTime = x.EndTime,
                               RoomName =x.Room.RoomName,
                               RoomId = x.Room.RoomId, 
                               LocationName = x.Room.Location.LocationName,
                               LocationId = x.Room.Location.LocationId,
                               UserName = x.User.Username

                               // Map other properties as needed
                           })
                           .ToListAsync();

            return meetingList;

        }

        public async Task RemoveDetail(int id)
        {
            
            await _meetingRoomDBContext.Database.ExecuteSqlInterpolatedAsync($"EXEC RemoveMeetingWithCheck {id}");
        }

        public async Task<string> UpdateDetail(BookedNewMeetingViewModel meeting)
        {
            var meetingIdParam = new SqlParameter("@MeetingId", meeting.MeetingId);
            var meetingTitleParam = new SqlParameter("@MeetingTitle", meeting.MeetingTitle);
            var startTimeParam = new SqlParameter("@StartTime", meeting.StartTime);
            var endTimeParam = new SqlParameter("@EndTime", meeting.EndTime);
            var roomIdParam = new SqlParameter("@RoomId", meeting.RoomId);
            var userIdParam = new SqlParameter("@UserId", meeting.UserId);

            var resultParam = new SqlParameter("@Result", SqlDbType.NVarChar, 50);
            resultParam.Direction = ParameterDirection.Output;

            await _meetingRoomDBContext.Database.ExecuteSqlRawAsync(
                "EXEC UpdateMeetingWithCheck @MeetingId,@MeetingTitle, @StartTime, @EndTime, @RoomId, @UserId, @Result OUT",
                meetingIdParam, meetingTitleParam, startTimeParam, endTimeParam, roomIdParam, userIdParam, resultParam);

            // Get the result from the output parameter
            string result = resultParam.Value.ToString();
            return result;
        }




        public async  Task<bool> CheckMeetingConflict(int meetingRoomId, DateTime startTime, DateTime endTime)
        {
           
                try
                {
                    var isAvailableParameter = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                    isAvailableParameter.Direction = ParameterDirection.Output;



                    await _meetingRoomDBContext.Database.ExecuteSqlRawAsync(
                        "EXEC CheckMeetingConflict @MeetingRoomId, @StartTime, @EndTime, @IsAvailable OUTPUT",
                        new SqlParameter("@MeetingRoomId", meetingRoomId),
                        new SqlParameter("@StartTime", startTime),
                        new SqlParameter("@EndTime", endTime),
                        isAvailableParameter);



                    return (bool)isAvailableParameter.Value;
                }
                catch (Exception ex)
                {



                    throw new Exception("Error checking room availability.", ex);
                }
            }        
    }
}
