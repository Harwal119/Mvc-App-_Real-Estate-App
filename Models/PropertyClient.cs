using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models
{
    public class PropertyClient: BaseEntity
    {
        public string PropertyId {get ; set;}
        public Property Property {get ; set;}
        public string ClientId {get ; set;}
        public Client Client {get ; set;}
    }
}