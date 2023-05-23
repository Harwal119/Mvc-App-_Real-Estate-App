using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IWalletRepository
    {
        Wallet Get(string id);
        Wallet Get(Expression<Func<Wallet, bool>> expression);
        Wallet GetByUserId(string userId);
        Wallet Add(Wallet wallet);
        Wallet Remove(Wallet wallet);
        IEnumerable<Wallet> GetAll();
        Wallet Update (Wallet wallet);
        int Save();
    }
}