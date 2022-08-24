using AuthorizationService.Model;
using AuthorizationService.Providers;
using AuthorizationService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthProvider provider;
        private IConfiguration config;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));
        Userdetails _user = new Userdetails();
        public LoginController(IAuthProvider provider, IConfiguration config)
        {
            this.provider = provider;
            this.config = config;
        }

        [HttpPost("AuthenicateUser")]
        [AllowAnonymous]
        public IActionResult AuthenticateUser([FromBody] Userdetails details)
        {
            _log4net.Info("---------------------------------------------------------------");
            _log4net.Info("AUTHORIZATION SERVICE BEGINS");
            _log4net.Info("Http Authentication Login request Initiated");

            var isValid = provider.Authenticate(details.Email, details.Password);
            if (!isValid)
            {
                _log4net.Error("401---Provided user details are invalid");
                _log4net.Info("AUTHORIZATION SERVICE ENDS");
                return Unauthorized();
            }
            
            var token = provider.GenerateAccessToken(details,config);
            if (token == null)
            {
                _log4net.Error("400----Token cannot be generated");
                _log4net.Info("AUTHORIZATION SERVICE ENDS");
                return BadRequest(token);
            }

            LoginResponse response = new LoginResponse
            {
                UserId = provider.GetUserid(details.Email),
                Email = details.Email,
                AccessToken = token
            };
            _log4net.Info("Http Authentication Login request Successful");
            _log4net.Info("AUTHORIZATION SERVICE ENDS");

            return Ok(response);
        }       

    }
}
