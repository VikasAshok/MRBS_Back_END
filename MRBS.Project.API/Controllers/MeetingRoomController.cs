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
        protected readonly IMeetingRoomService _meetingRoomService;
        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService= meetingRoomService;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllDetail()
        {
            return Ok(await _meetingRoomService.GetAllDetail());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _meetingRoomService.GetById(id));

        }

        [HttpGet("GetByLocationId")]
        public async Task<IActionResult> GetByLocationId(int id)
        {
            return Ok(await _meetingRoomService.GetByLocationId(id));

        }


        [HttpPost("AddDetail")]
        public async Task<IActionResult> AddDetail(MeetingRoom meetingRoom)
        {
            var result = await _meetingRoomService.AddDetail(meetingRoom);
            return Ok(result);
        }
        [HttpPut("UpdateDetail")]
        public async Task<IActionResult> UpdateDetail(MeetingRoom meetingRoom)
        {
            var result = await _meetingRoomService.UpdateDetail(meetingRoom);
            return Ok(result);
        }
        [HttpDelete("RemoveDetail")]
        public async Task<IActionResult> RemoveDetail(int id)
        {
            await _meetingRoomService.RemoveDetail(id);
            return Ok();
        }
    }
}
