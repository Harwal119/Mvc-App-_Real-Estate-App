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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context)
        {
            _context = context;
        }
        public Role Get(string id)
        {
            var user =  _context.Roles
           .Where(c => c.IsDeleted == false)
           .Include(c => c.UserRoles)
           .ThenInclude(c => c.User)
           .SingleOrDefault(c => c.Id == id);
            return user;
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            var user =  _context.Roles
           .Where(c => c.IsDeleted == false)
           .Include(c => c.UserRoles)
           .ThenInclude(c => c.User)
           .SingleOrDefault(expression);
            return user;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles
           .Where(a => a.IsDeleted == false)
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.User)
           .ToList();
        }

        public IEnumerable<Role> GetSelected(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(expression)
           .ToList();
        }
    }
}