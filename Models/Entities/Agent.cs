using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class Agent : BaseEntity
    {
        public string UserId {get ; set;}
        public User User {get ; set;}
        public IEnumerable<PropertyAgent> PropertyAgents {get ; set;}
    }
}