using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRBS.Project.BusinessAccessLayer.Services;

namespace MRBS.Project.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLocations()
        {
            return Ok(await _locationService.GetAllLocations());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(await _locationService.GetLocationById(id));
        }
    }
}
