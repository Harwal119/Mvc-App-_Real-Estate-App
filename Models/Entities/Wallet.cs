using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class Wallet
    {
        public string Id {get ; set;} = Guid.NewGuid().ToString();
        public double Balance {get ; set;}
        public double Amount {get ; set;}
        public bool IsDeleted {get ; set;}
        public string UserId {get ; set;}
        public User User {get ; set;}

        
    }
}