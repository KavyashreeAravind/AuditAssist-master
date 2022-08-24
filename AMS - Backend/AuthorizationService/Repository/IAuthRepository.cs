using AuthorizationService.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public interface IAuthRepository
    {
        public bool Authenticate(string email, string password);
        int GetUserid(string email);
        Userdetails GetUser(string email);
        string GenerateAccessToken(Userdetails userInfo, IConfiguration config);
    }
}
