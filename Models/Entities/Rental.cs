using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class Rental :BaseEntity
    {
        public string ExpiryDate {get ; set;}
        public double Amount {get ; set;}
        public string PropertyId {get ; set;}
        public Property Property {get ; set;}
        public string ClientId {get ; set;}
        public Client Client {get ; set;}

    }
}