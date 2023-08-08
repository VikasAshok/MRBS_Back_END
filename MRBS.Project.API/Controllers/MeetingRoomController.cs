using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRBS.Project.API.Models;
using MRBS.Project.BusinessAccessLayer.Services;

namespace MRBS.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDetails()
        {
            return Ok(await _meetingRoomService.GetAllDetails());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _meetingRoomService.GetMeetingRoomById(id));
        }

        [HttpGet("GetByLocationId")]
        public async Task<IActionResult> GetByLocationId(int id)
        {
            return Ok(await _meetingRoomService.GetMeetingRoomsByLocationId(id));
        }

        [HttpPost("AddDetail")]
        public async Task<IActionResult> AddDetail(MeetingRoom meetingRoom)
        {
            var result = await _meetingRoomService.AddMeetingRoomDetail(meetingRoom);
            return Ok(result);
        }

        [HttpPut("UpdateDetail")]
        public async Task<IActionResult> UpdateDetail(MeetingRoom meetingRoom)
        {
            var result = await _meetingRoomService.UpdateMeetingRoomDetail(meetingRoom);
            return Ok(result);
        }

        [HttpDelete("RemoveDetail")]
        public async Task<IActionResult> RemoveDetail(int id)
        {
            await _meetingRoomService.RemoveMeetingRoomDetail(id);
            return Ok();
        }
    }
}
