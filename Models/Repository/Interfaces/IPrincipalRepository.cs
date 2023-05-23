using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IPrincipalRepository : IBaseRepository<Principal>
    {
        Principal Get(string id);
        Principal Get(Expression<Func<Principal,bool>> expression);
        IEnumerable<Principal> GetSelected(List<string> ids);
        IEnumerable<Principal> GetSelected(Expression<Func<Principal,bool>> expression);
        IEnumerable<Principal> GetAll();
    }
}