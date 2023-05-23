using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Data;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Repository.Implementation
{
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(Context context)
        {
            _context = context;
        }
        public Manager Get(string id)
        {
            var manager = _context.ManagerList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .SingleOrDefault(c =>c.Id == id);
            return manager;
        }

        public Manager Get(Expression<Func<Manager, bool>> expression)
        {
             var manager = _context.ManagerList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .SingleOrDefault(expression);
             return manager;
        }

        public IEnumerable<Manager> GetAll()
        {
             return _context.ManagerList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .ToList();
        }

        public IEnumerable<Manager> GetSelected(List<string> ids)
        {
             return _context.ManagerList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .ToList();
        }

        public IEnumerable<Manager> GetSelected(Expression<Func<Manager, bool>> expression)
        {
            return _context.ManagerList
            .Where(expression)
            .Include(c => c.User)
            .ToList();
        }
    }
}