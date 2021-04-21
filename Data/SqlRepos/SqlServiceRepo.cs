using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using meistrelis.Data.IRepos;
using meistrelis.Models;
using Microsoft.EntityFrameworkCore;
using user.PostgreSQL;

namespace meistrelis.Data.SqlRepos
{
    public class SqlServiceRepo : IServiceRepo
    {
        private readonly MeistrelisContext _context;
        
        public SqlServiceRepo(MeistrelisContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Service> GetAppServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(p => p.Id == id);
        }
    }
}