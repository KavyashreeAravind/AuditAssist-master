using AuthorizationService.Model;
using AuthorizationService.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IAuthRepository _authRepo;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthProvider));
        public AuthProvider(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        public AuthProvider() { }
        public string GenerateAccessToken(Userdetails userInfo, IConfiguration config)
        {
            _log4net.Info(" GenerateAccessToken method of AuthProvider Called ");
            string token = _authRepo.GenerateAccessToken(userInfo,config);
            return token;
        }

        public int GetUserid(string email)
        {
            _log4net.Info(" GetUserid method of AuthProvider Called ");
            int id = _authRepo.GetUserid(email);
            return id;
        }
        public Userdetails GetUser(string email)
        {
            _log4net.Info(" GetUser method of AuthProvider Called ");
            Userdetails user = _authRepo.GetUser(email);
            return user;

        }
        public bool Authenticate(string email, string password)
        {
            _log4net.Info("Authenticate method of AuthProvider Called ");
            bool isValidUser = _authRepo.Authenticate(email,password);
            return isValidUser;

        }
    }
}
