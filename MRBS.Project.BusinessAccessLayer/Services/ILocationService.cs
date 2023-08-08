using MRBS.Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(int id);
    }
}
