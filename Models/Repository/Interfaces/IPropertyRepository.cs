using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        Property Get(string id);
        Property Get(Expression<Func<Property,bool>> expression);
        IEnumerable<Property> GetSelected(List<string> ids);
        IEnumerable<Property> GetSelected(Expression<Func<Property,bool>> expression);
        IEnumerable<Property> GetAll();
        IEnumerable<Property> GetAllAvailable();
    }
}