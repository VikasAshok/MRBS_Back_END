using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRBS.Project.BusinessAccessLayer.Services;
using MRBS.Project.DataAccessLayer.Repository;

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
            _locationService= locationService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllLocation()
        {
            return Ok(await _locationService.GetAllLocation());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(await _locationService.GetLocationById(id));
        }

    }
}
