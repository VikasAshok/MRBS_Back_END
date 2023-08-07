using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.BusinessAccessLayer
{
    public static class Encrpytion
    {
        public static string ConvertToEncrypt(string Password, string key)
        {
            if (string.IsNullOrWhiteSpace(Password)) return string.Empty;
            Password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(passwordBytes);
        }
    }
}
