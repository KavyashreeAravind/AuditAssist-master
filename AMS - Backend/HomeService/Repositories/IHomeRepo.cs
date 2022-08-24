using HomeService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeService.Repositories
{
    public interface IHomeRepo
    {
        public Task<IEnumerable<Audit>> AuditByUserId(int id);

        public bool Login(string username, string password);
    }
}
