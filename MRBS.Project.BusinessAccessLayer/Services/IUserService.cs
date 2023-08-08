using MRBS.Project.API.Models;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public interface IUserService
    {
        User ValidateUser(Login loginuser);
        List<string> GenerateToken(User user);
       
    }
}
