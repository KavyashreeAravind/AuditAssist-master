using AuditCheckListService.Models;
using System.Collections.Generic;

namespace AuditCheckListService.Providers
{
    public interface IAuditCheckListProvider
    {
        public List<QuestionsAndType> AuditChecklistQuestions(string auditType);
    }
}
