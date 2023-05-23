using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string id);
        User Get(Expression<Func<User,bool>> expression);
        IEnumerable<User> GetSelected(List<string> ids);
        IEnumerable<User> GetSelected(Expression<Func<User,bool>> expression);
        IEnumerable<User> GetAll();
    }
}