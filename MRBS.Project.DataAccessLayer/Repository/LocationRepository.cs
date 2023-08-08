using Microsoft.EntityFrameworkCore;
using MRBS.Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MeetingRoomDBContext _meetingRoomDBContext;

        public LocationRepository(MeetingRoomDBContext meetingRoomDBContext)
        {
            _meetingRoomDBContext = meetingRoomDBContext;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _meetingRoomDBContext.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _meetingRoomDBContext.Locations.FindAsync(id);
        }
    }
}
