using System;
using System.Collections.Generic;

namespace HomeService.Models
{
    public partial class Audit
    {
        public int Auditid { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManagerName { get; set; }
        public string ApplicationOwnerName { get; set; }
        public string AuditType { get; set; }
        public DateTime? AuditDate { get; set; }
        public string ProjectExecutionStatus { get; set; }
        public string RemedialActionDuration { get; set; }
        public int? Userid { get; set; }
    }
}
