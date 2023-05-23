using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Data;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Repository.Implementation
{
    public class PrincipalRepository : BaseRepository<Principal>, IPrincipalRepository
    {
        public PrincipalRepository(Context context)
        {
            _context = context;
        }
        public Principal Get(string id)
        {
            var principal = _context.PrincipalList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Properties)
            .SingleOrDefault(c =>c.Id == id);
            return principal;
        }

        public Principal Get(Expression<Func<Principal, bool>> expression)
        {
            var principal = _context.PrincipalList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Properties)
            .SingleOrDefault(expression);
            return principal;
        }

        public IEnumerable<Principal> GetAll()
        {
            return _context.PrincipalList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Properties)
            .ToList();
        }

        

        public IEnumerable<Principal> GetSelected(List<string> ids)
        {
            return _context.PrincipalList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Properties)
            .ToList();
        }

        public IEnumerable<Principal> GetSelected(Expression<Func<Principal, bool>> expression)
        {
            return _context.PrincipalList
            .Where(expression)
            .Include(c => c.User)
            .Include(c => c.Properties)
            .ToList();
        }
    }
}