using AuthorizationService.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public interface IAuthProvider
    {
        public bool Authenticate(string email, string password);
        public int GetUserid(string email);
        public Userdetails GetUser(string email);
        string GenerateAccessToken(Userdetails userInfo, IConfiguration config);



    }
}
