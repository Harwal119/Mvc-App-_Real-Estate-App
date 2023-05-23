using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Create (T entity);
        T Update (T entity);
        int save();
        
    }
}