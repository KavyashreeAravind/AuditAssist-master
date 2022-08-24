using HomeService.Models;
using HomeService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeService.Providers
{
    public class HomeProvider:IHomeProvider
    {
        private IHomeRepo _repos;

        public HomeProvider() { }

        public HomeProvider(IHomeRepo repos)
        {
            this._repos = repos;
        }
        
        public Task<IEnumerable<Audit>> AuditByUserId(int Userid)
        {
            return _repos.AuditByUserId(Userid);

        }
        public bool Login(string username, string password)
        {
            return _repos.Login(username, password);
        }
    }
}
