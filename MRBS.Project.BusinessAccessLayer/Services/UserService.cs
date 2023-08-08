using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MRBS.Project.API.Models;
using MRBS.Project.BusinessAccessLayer.ConfigKeys;
using MRBS.Project.DataAccessLayer.Repository;
using MRBS.Project.DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer.Services
{
    public class UserService : IUserService
    {      
        private readonly IUserRepository _userRepository;
        private readonly Encryption _encryption;
        private readonly Jwt _jwt;
        public UserService(IUserRepository userRepository, IOptions<Encryption> encryption, IOptions<Jwt> jwt)
        {
            _userRepository = userRepository;
            _encryption = encryption.Value;
            _jwt = jwt.Value;
        }



        public List<string> GenerateToken(User user)
        {
            try
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _jwt.Subject),
                        new Claim("Userid", user.UserId.ToString()),
                        new Claim("Username", user.Username)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _jwt.Issuer,
                    _jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToUInt32(_jwt.ExpireTime)), //appsettings > default 20mins
                    signingCredentials: signIn);

                //if (token.ToString().IsNullOrEmpty() || string.IsNullOrWhiteSpace(token.ToString()))
                //{
                //    throw new Exception("Value for token is not Valid, Kindly connect with your administrator");
                //}

                var strToken = new List<string>
                {
                    new JwtSecurityTokenHandler().WriteToken(token),
                    token.ValidTo.ToString()
                };

                return strToken;

            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public User ValidateUser(Login loginuser)
        {
            try
            {
                User? user = _userRepository.ValidateUser(loginuser.Username);
                if (user != null)
                {
                    //get key from appsettings to encrypt the password before comparing
                    string? keyPassword = _encryption.Key;

                    var pswd = Encrpytion.ConvertToEncrypt(loginuser.Password, keyPassword);
                    if (pswd != user.Password)
                        user = null;
                }
                else
                    user = null;
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
