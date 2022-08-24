using HomeService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeService.Providers
{
    public interface IHomeProvider
    {
        public Task<IEnumerable<Audit>> AuditByUserId(int id);

        public bool Login(string username, string password);
    }
}
