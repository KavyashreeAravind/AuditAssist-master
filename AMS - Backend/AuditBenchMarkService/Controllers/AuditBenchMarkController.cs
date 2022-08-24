
using AuditBenchmarkService.Repository;
using AuditBenchmarkService.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditBenchMarkController : ControllerBase
    {
        private readonly IBenchMarkProvider _context;
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(AuditBenchMarkController));

        public AuditBenchMarkController(IBenchMarkProvider context)
        {
            _context = context;
        }

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchMarkController));

        [HttpGet("{auditType}")]
        public IActionResult GetAuditNoCount(string auditType)
        {
            _log4net.Info("AUDIT BENCH MARK SERVICE STARTED");
            _log4net.Info("Audit Benchmark process initiated !!");
            if (!ModelState.IsValid)
            {
                _log4net.Error("400-Model State is invalid");
                _log4net.Info("AUDIT BENCH MARK SERVICE ENDS");
                return BadRequest(ModelState);
            }
            try
            {
                var count = _context.GetAuditNoCount(auditType);
                if (count == null || count.Count==0)
                {
                    _log4net.Error("404-Data not found");
                    _log4net.Info("AUDIT BENCH MARK SERVICE ENDS");
                    return NotFound(count);
                }
                _log4net.Error("Audit Benchmark process completed. No count delivered to AuditSeverityService");
                _log4net.Info("AUDIT BENCH MARK SERVICE ENDS");
                _log4net.Info("");
                return Ok(count);
            }
            catch (Exception )
            {

                return BadRequest();
            }
            
        }
    }
}
