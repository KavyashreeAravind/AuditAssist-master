using HomeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeService.Repositories
{
    public class HomeRepo:IHomeRepo
    {
        private readonly AMSContext _context;
        public HomeRepo() { }

        public HomeRepo(AMSContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Audit>> AuditByUserId(int id)
        {
            if (id == null)
                throw new ArgumentException();
            try
            {
                id = System.Convert.ToInt32(id);

                var audit = await _context.Audit.Where(a => a.Userid == id).ToListAsync();

                return audit;
            }
            catch
            {
                throw new Exception("Could not retrieve audit details.");
            }
        }

        public bool Login(string username,string password)
        {
            var data = _context.Userdetails.FirstOrDefault(a => a.Email == username && a.Password == password);
            return data != null;
        }
    }
}
