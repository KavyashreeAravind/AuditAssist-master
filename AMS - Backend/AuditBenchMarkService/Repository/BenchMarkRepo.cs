
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkService.Repository
{
    public class BenchMarkRepo : IBenchMarkRepo
    {
        Dictionary<string,int> _auditDict = new Dictionary<string,int>();
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BenchMarkRepo));

        public BenchMarkRepo()
        {

        }

        public BenchMarkRepo(Dictionary<string,int> auditDict)
        {
            _auditDict = auditDict;
        }

        public Dictionary<string,int> GetAuditNoCount(string auditType)
        {
            _log4net.Info("GetNoCount of BenchMarkRepo has been called");

            if (auditType == "Internal" && !(_auditDict.ContainsKey("Internal")))
            {
                _auditDict.Add("Internal", 3);
            }
            else if (auditType == "PayRoll" && !(_auditDict.ContainsKey("PayRoll")))
            {
                _auditDict.Add("PayRoll", 3);
            }
            else if (auditType == "SOX" && !(_auditDict.ContainsKey("SOX")))
            {
                _auditDict.Add("SOX", 2);
            }
            else if (auditType == "Financial" && !(_auditDict.ContainsKey("Financial")))
            {
                _auditDict.Add("Financial", 2);
            }
            return _auditDict;              

        }       
    }
}
