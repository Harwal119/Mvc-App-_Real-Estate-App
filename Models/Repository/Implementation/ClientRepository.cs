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
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(Context context)
        {
            _context = context;
        }
        public Client Get(string id)
        {
           var client = _context.ClientList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Rentals)
            .Include(c => c.Purchases)
            .Include(c => c.PropertyClients)
            .Include(c => c.Transactions)
            .SingleOrDefault(c =>c.Id == id);
            return client;
            
        }

        public Client Get(Expression<Func<Client, bool>> expression)
        {
             var client = _context.ClientList
            .Include(c => c.User)
            .Include(c => c.Rentals)
            .Include(c => c.Purchases)
            .Include(c => c.PropertyClients)
            .Include(c => c.Transactions)
            .Where(c => c.IsDeleted == false)
            .SingleOrDefault(expression);
            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.ClientList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .Include(c => c.Rentals)
            .Include(c => c.Purchases)
            .Include(c => c.PropertyClients)
            .Include(c => c.Transactions)
            .ToList();
        }

        public IEnumerable<Client> GetSelected(List<string> ids)
        {
            return _context.ClientList
            .Include(c => c.User)
            .Include(c => c.Rentals)
            .Include(c => c.Purchases)
            .Include(c => c.PropertyClients)
            .Include(c => c.Transactions)
            .Where(c => c.IsDeleted == false)
            .ToList();
            
        }

        public IEnumerable<Client> GetSelected(Expression<Func<Client, bool>> expression)
        {
            return _context.ClientList
            .Include(c => c.User)
            .Include(c => c.Rentals)
            .Include(c => c.Purchases)
            .Include(c => c.PropertyClients)
            .Include(c => c.Transactions)
            .Where(expression).ToList();
        }
    }
}