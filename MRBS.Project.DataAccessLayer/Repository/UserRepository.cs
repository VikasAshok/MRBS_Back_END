using Microsoft.EntityFrameworkCore;
using MRBS.Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MeetingRoomDBContext _meetingRoomDBContext;
        public UserRepository(MeetingRoomDBContext meetingRoomDBContext)
        {
            _meetingRoomDBContext = meetingRoomDBContext;
        }
        public User? ValidateUser(string username)
        {
            User? user = _meetingRoomDBContext.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }
    }
}
