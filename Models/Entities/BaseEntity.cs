using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class BaseEntity
    {
        public string Id{get; set;} = Guid.NewGuid().ToString();
        public bool IsDeleted{get;set;}
        public DateTime DateCreated{get; set;} = DateTime.Now;
        public string CreatedBy{get; set;}

    }
}