using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Client Get(string id);
        Client Get(Expression<Func<Client,bool>> expression);
        IEnumerable<Client> GetSelected(List<string> ids);
        IEnumerable<Client> GetSelected(Expression<Func<Client,bool>> expression);
        IEnumerable<Client> GetAll();
    }
}