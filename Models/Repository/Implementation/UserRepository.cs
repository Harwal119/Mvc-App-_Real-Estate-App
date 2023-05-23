using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Data;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Get(string id)
        {
            var user =  _context.UserList
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .SingleOrDefault(a => a.Id == id);
           return user;
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            var user =  _context.UserList
           .Where(a => a.IsDeleted == false)
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .SingleOrDefault(expression);
           return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.UserList
           .Where(a => a.IsDeleted == false)
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .ToList();
        }

        public IEnumerable<User> GetSelected(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetSelected(Expression<Func<User, bool>> expression)
        {
            return _context.UserList
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(expression)
           .ToList();
        }
    }
}