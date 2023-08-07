using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Project.DataAccessLayer.ViewModel
{
    public class Login
    {
      
        //[Required(ErrorMessage = "User name is required.")]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter only Alphabets.")]
        //[MinLength(5, ErrorMessage = "User name must be at least 5 characters.")]
        //[MaxLength(20, ErrorMessage = "User name can't exceed 20 characters.")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{5,20}$", ErrorMessage = "Password must be 5 or Greater than 5 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]  
        public string Password { get; set; }
    }
}
