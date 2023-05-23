using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IAgentRepository : IBaseRepository<Agent>
    {
        Agent Get(string id);
        Agent Get(Expression<Func<Agent,bool>> expression);
        IEnumerable<Agent> GetSelected(List<string> ids);
        IEnumerable<Agent> GetSelected(Expression<Func<Agent,bool>> expression);
        IEnumerable<Agent> GetAll();
    }
}