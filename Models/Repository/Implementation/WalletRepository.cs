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
    public class WalletRepository : IWalletRepository
    {   private readonly Context _context;
        public WalletRepository(Context context)
        {
            _context = context;
        }
        public Wallet Add(Wallet wallet)
        {
           _context.Set<Wallet>().Add(wallet);
           return wallet;
        }
        public Wallet Update(Wallet wallet)
        {
           _context.Set<Wallet>().Update(wallet);
           return wallet;
        }

        public Wallet Get(string id)
        {
            var wallet =  _context.WalletList
           .Where(a => a.IsDeleted == false)
           .Include(c => c.User)
           .SingleOrDefault(a => a.Id == id);
           return wallet;
        }

        public Wallet Get(Expression<Func<Wallet, bool>> expression)
        {
            var wallet =  _context.WalletList
           .Where(a => a.IsDeleted == false)
           .Include(c => c.User)
           .SingleOrDefault(expression);
           return wallet;
        }

        public IEnumerable<Wallet> GetAll()
        {
            return _context.WalletList
            .Where(c => c.IsDeleted == false)
            .Include(c => c.User)
            .ToList();
        }

        public Wallet GetByUserId(string userId)
        {
            var wallet =  _context.WalletList
           .Where(a => a.IsDeleted == false)
           .Include(c => c.User)
           .SingleOrDefault(a => a.UserId == userId);
           return wallet;
        }

        public Wallet Remove(Wallet wallet)
        {
            _context.WalletList.Remove(wallet);
            return wallet;
        }
        public int Save()
        {
            var change = _context.SaveChanges();
            return change;
        }
    }
}