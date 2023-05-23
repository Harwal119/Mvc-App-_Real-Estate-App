using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models
{
    public class PropertyAgent : BaseEntity
    {
        public string PropertyId {get ; set;}
        public Property Property {get ; set;}
        public string AgentId {get ; set;}
        public Agent Agent {get ; set;}
    }
}