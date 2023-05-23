using System.Runtime.InteropServices;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateMvcApp.Models;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Data
{
    public class Context : DbContext
    {
    
        
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Manager> ManagerList {get ; set;}
        public DbSet<Principal> PrincipalList {get ; set;}
        public DbSet<Client> ClientList {get ; set;}
        public DbSet<Agent> AgentList {get ; set;}
        public DbSet<User> UserList {get ; set;}
        public DbSet<PropertyAgent> PropertyAgentList {get ; set;}
        public DbSet<PropertyClient> PropertyClientList {get ; set;}
        public DbSet<Rental> RentalList {get ; set;}
        public DbSet<Purchase> PurchaseList {get ; set;}
        public DbSet<Property> PropertyList {get ; set;}
        public DbSet<Transaction> TransactiontList {get ; set;}
        public DbSet<Role> Roles {get ; set;}
        public DbSet<UserRole> UserRoles {get ; set;}
        public DbSet<Wallet> WalletList {get ; set;}
    }
}