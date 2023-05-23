using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class Client : BaseEntity
    {
        public string Picture {get ; set;}
        public string UserId {get ; set;}
        public User User {get ; set;}
        public IEnumerable<Transaction> Transactions {get ; set;}
        public IEnumerable<PropertyClient> PropertyClients {get; set;}
        public IEnumerable<Rental> Rentals {get; set;}
        public IEnumerable<Purchase> Purchases {get; set;}

        

    }
}