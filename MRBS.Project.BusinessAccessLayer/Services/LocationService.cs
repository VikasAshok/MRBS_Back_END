using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public class LocationService : ILocationService
    {
        protected readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _locationRepository.GetAllLocations();
        }

        public async Task<Location> GetLocationById(int id)
        {
           return await _locationRepository.GetLocationById(id);
        }
    }
}
