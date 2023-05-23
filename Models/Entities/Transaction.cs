using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Enums;

namespace RealEstateMvcApp.Models.Entities
{
    public class Transaction : BaseEntity
    {
        public double Amount {get ; set;}
        public DateTime DateTime {get ; set;} = DateTime.Now;
        public string ClientId {get ; set;}
        public Client Client {get ; set;}
        public string Description {get ; set;}
        public string PropertyId {get ; set;}
        public Property Property {get ; set;}
        

    }
}