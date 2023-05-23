using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Dtos
{
    public class WalletDto
    {
        public string Id {get ; set;} 
        public double Balance {get ; set;}
        public bool IsDeleted {get ; set;}
        public string ClientId {get ; set;}
        public Client Client {get ; set;}

    }
}