using AuditBenchmarkService.Repository;
using System.Collections.Generic;

namespace AuditBenchmarkService.Providers
{
    public class BenchMarkProvider:IBenchMarkProvider
    {
        private readonly IBenchMarkRepo _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BenchMarkProvider));

        public BenchMarkProvider()
        {

        }

        public BenchMarkProvider(IBenchMarkRepo context)
        {
            _context = context;
        }

        public Dictionary<string, int> GetAuditNoCount(string auditType)
        {
            _log4net.Info("GetNoCount of BenchMarkProvider has been called");
            return _context.GetAuditNoCount(auditType);

        }
    }
}
