using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateMvcApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name{ get;set;}
        public string Email{ get;set;}
        public string Password{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Address {get; set;}
        public double Wallet{get;set;}
        public ICollection<UserRole> UserRoles{ get;set;} = new HashSet<UserRole>();

    }
}