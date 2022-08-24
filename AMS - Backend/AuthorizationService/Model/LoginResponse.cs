using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Model
{
    public class LoginResponse
    {
        public int UserId { get; set;}
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
