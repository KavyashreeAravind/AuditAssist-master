
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkService.Repository
{
    public interface IBenchMarkRepo
    { 
        
        Dictionary<string,int> GetAuditNoCount(string auditType);
        


    }
    
}
