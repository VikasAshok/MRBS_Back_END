using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MRBS.Project.API.Models;
using MRBS.Project.BusinessAccessLayer.Services;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;

namespace MRBS.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMeetingDetails()
        {
            return Ok(await _meetingService.GetAllMeetings());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetMeetingDetailById(int id)
        {
            return Ok(await _meetingService.GetMeetingById(id));
        }

        [HttpPost("AddMeeting")]
        public async Task<IActionResult> AddMeeting(BookedNewMeetingViewModel meeting)
        {
            try
            {
                // Check for conflicts
                bool hasConflict = await _meetingService.CheckMeetingConflict(meeting.RoomId, meeting.StartTime, meeting.EndTime);

                if (hasConflict)
                {
                    // Conflict detected, return an error response
                    return Conflict("This room is already booked for the selected time.");
                }

                // No conflict, proceed to save the meeting
                await _meetingService.AddMeeting(meeting);

                return Ok("Meeting booked successfully.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                return StatusCode(500, "An error occurred while booking the meeting.");
            }
        }

        [HttpPut("UpdateMeeting")]
        public async Task<IActionResult> UpdateMeeting(BookedNewMeetingViewModel meeting)
        {
            string result = await _meetingService.UpdateMeeting(meeting);

            if (result == "SUCCESS")
            {
                return Ok("Meeting updated successfully!");
            }
            else if (result == "CONFLICT")
            {
                return BadRequest("The meeting time conflicts with an existing booking.");
            }
            else
            {
                return StatusCode(500, "An error occurred while updating the meeting.");
            }
        }

        [HttpDelete("DeleteMeeting")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            try
            {
                await _meetingService.DeleteMeeting(id);
                return Ok("Meeting deleted successfully.");
            }
            catch (SqlException ex) when (ex.Number == 50000) // Catch the custom error raised by the stored procedure
            {
                return Conflict("Cannot delete the meeting as it is currently ongoing.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the meeting.");
            }
        }
    }
}
