using System.Collections.Generic;

namespace AuditBenchmarkService.Providers
{
    public interface IBenchMarkProvider
    {
        public Dictionary<string, int> GetAuditNoCount(string auditType);
    }
}
