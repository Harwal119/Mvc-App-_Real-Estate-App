using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class Principal : BaseEntity
    {
        public string UserId {get ; set;}
        public User User {get ; set;}
        public List<Property> Properties {get ;set;}
    }
}