﻿using MRBS.Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocation();
        Task<Location> GetLocationById(int id);
    }
}
