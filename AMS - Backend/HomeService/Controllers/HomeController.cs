using HomeService.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HomeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IHomeProvider _context;

        public HomeController(IHomeProvider context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("GetAuditByUserId/{userId}")]
        public async Task<IActionResult> GetAuditByUserId(int userId)
        {
            _log4net.Info("HOME SERVICE BEGINS");
            _log4net.Info("Audit details retreival process begins");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var audit = _context.AuditByUserId(userId);
                _log4net.Info("Audit details retreived successfully");
                _log4net.Info("HOME SERVICE ENDS");
                return Ok(audit);
            }
            catch (Exception)
            {
                _log4net.Error("400-Bad Request");
                _log4net.Info("HOME SERVICE ENDS");
                return BadRequest();
            }

        }

    }
}
