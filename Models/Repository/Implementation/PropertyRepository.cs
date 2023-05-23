using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Data;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Enums;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Repository.Implementation
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(Context context)
        {
            _context = context;
        }
        public Property Get(string id)
        {
            var property = _context.PropertyList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .SingleOrDefault(c =>c.Id == id);
            return property;
        }

        public Property Get(Expression<Func<Property, bool>> expression)
        {
            var property = _context.PropertyList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .SingleOrDefault(expression);
            return property;
        }

        public IEnumerable<Property> GetAllAvailable()
        {
             return _context.PropertyList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .Where(X => X.Status != (int)Status.NotAvailableForRent && X.Status != (int)Status.NotAvailableForpurchase)
            .ToList();
        
        }

        public IEnumerable<Property> GetAll()
        {
             return _context.PropertyList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .ToList();
        
        }

        public IEnumerable<Property> GetSelected(List<string> ids)
        {
            return _context.PropertyList
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .Where(c => c.IsDeleted == false)
            .ToList();
        }

        public IEnumerable<Property> GetSelected(Expression<Func<Property, bool>> expression)
        {
             return _context.PropertyList
            .Include(c => c.Principal)
            .Include(c => c.Rentals)
            .Include(c => c.PropertyAgents)
            .Include(c => c.PropertyClients)
            .Where(expression)
            .ToList();
        }
    }
}