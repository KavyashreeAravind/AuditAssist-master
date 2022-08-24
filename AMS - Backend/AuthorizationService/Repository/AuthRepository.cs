using AuthorizationService.DataAccess;
using AuthorizationService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public class AuthRepository : IAuthRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepository));
        AuditManagementSystemContext _context = new AuditManagementSystemContext();
        private readonly string tokenKey;
        public AuthRepository(string TokenKey)
        {
            
            this.tokenKey = TokenKey;
            

        }
        public AuthRepository()
        {

        }
        

        public AuthRepository(string TokenKey,AuditManagementSystemContext context)
        {
            this.tokenKey = TokenKey;
            _context = context;
        }


        public bool Authenticate(string email, string password)
        {
            _log4net.Info("Authenticate method of AuthRepository Called ");
            if (!_context.Userdetails.Any(u => u.Email == email && u.Password == password))
            {
                return false;

            }

            return true;
        }     
        
        public int GetUserid(string email)
        {
            _log4net.Info("GetUserid method of AuthRepository Called ");
            int userId =  _context.Userdetails.Single(user => user.Email == email).Userid;
            return userId;
        }

        public string GenerateAccessToken(Userdetails userInfo,IConfiguration _config)
        {
            _log4net.Info("GenerateAccessToken method of AuthRepository Called ");
            if (userInfo == null)
                return null;
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public Userdetails GetUser(string email)
        {
            _log4net.Info("GetUser method of AuthRepository Called ");
            return _context.Userdetails.Single(user => user.Email == email);
        }
    }
    }
