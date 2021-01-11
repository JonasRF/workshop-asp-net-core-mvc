using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartmentServices
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentServices(SalesWebMVCContext context)
        {
            _context = context;
        }
       
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
