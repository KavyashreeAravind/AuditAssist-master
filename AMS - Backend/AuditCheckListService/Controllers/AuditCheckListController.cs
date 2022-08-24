using AuditCheckListService.Models;
using AuditCheckListService.Providers;
using AuditCheckListService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditCheckListService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditCheckListController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditCheckListController));
        private readonly IAuditCheckListProvider _context;

        public AuditCheckListController(IAuditCheckListProvider context) 
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("{auditType}")]
        public IActionResult AuditChecklistQuestions(string auditType)
        {
            _log4net.Info("AUDIT CHECKLIST SERVICE STARTS");
            _log4net.Info("Get Questions By AuditType Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var questions = _context.AuditChecklistQuestions(auditType);
                _log4net.Info("Questions for Audit Type " + auditType + " Was Called");
                if (questions == null)
                {
                    _log4net.Error("404-No questions found");
                    _log4net.Info("AUDIT CHECKLIST SERVICE ENDS");
                    return NotFound(questions);
                }
                var questionList = new List<string>();
                foreach (var question in questions)
                    questionList.Add(question.Questions);
                _log4net.Error("200-Questions retreived");
                _log4net.Info("AUDIT CHECKLIST SERVICE ENDS");
                return Ok(questionList);
            }
            catch (Exception)
            {
                _log4net.Error("400-Bad request");
                _log4net.Info("AUDIT CHECKLIST SERVICE ENDS");
                return BadRequest();
            }
        }
    }
}
