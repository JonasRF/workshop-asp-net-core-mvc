using Microsoft.EntityFrameworkCore;
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
       
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
