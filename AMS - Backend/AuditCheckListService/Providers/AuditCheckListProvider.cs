using AuditCheckListService.Models;
using AuditCheckListService.Repositories;
using System.Collections.Generic;

namespace AuditCheckListService.Providers
{
    public class AuditCheckListProvider:IAuditCheckListProvider
    {
        IAuditChecklistRepos _repo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditCheckListProvider));
        public AuditCheckListProvider() { }

        public AuditCheckListProvider(IAuditChecklistRepos repo)
        {
            _repo = repo;
        }
        public List<QuestionsAndType> AuditChecklistQuestions(string auditType)
        {
            _log4net.Info("AuditCheckList questions method of AuditCheckProvider called");
            return _repo.AuditChecklistQuestions(auditType);
        }
    }
}
