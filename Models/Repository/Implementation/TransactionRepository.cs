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
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context context)
        {
            _context = context;
        }
        public Transaction Get(string id)
        {
             var property = _context.TransactiontList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.PropertyId)
            .Include(c => c.ClientId)
            .SingleOrDefault(c =>c.Id == id);
            return property;
        }

        public Transaction Get(Expression<Func<Transaction, bool>> expression)
        {
             var property = _context.TransactiontList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.PropertyId)
            .Include(c => c.ClientId)
            .SingleOrDefault(expression);
            return property;
        }

        public IEnumerable<Transaction> GetAll()
        {
             return _context.TransactiontList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.ClientId)
            .Include(c => c.PropertyId)
            .ToList();
        }

        public IEnumerable<Transaction> GetSelected(List<string> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetSelected(Expression<Func<Transaction, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}