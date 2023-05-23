using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Transaction Get(string id);
        Transaction Get(Expression<Func<Transaction,bool>> expression);
        IEnumerable<Transaction> GetSelected(List<string> ids);
        IEnumerable<Transaction> GetSelected(Expression<Func<Transaction,bool>> expression);
        IEnumerable<Transaction> GetAll();
    }
}