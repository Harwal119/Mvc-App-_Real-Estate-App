using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Dtos
{
    public class TransactionDto
    {
        public string Id {get ; set;}
        public double Amount {get ; set;}
        public DateTime DateTime {get ; set;} = DateTime.Now;
        public string Description {get ; set;}
        public string PropertyId {get ; set;}
        public Property Property {get ; set;}
    }
    // public class CreateTransactionReguestModel
    // {
    //     public double Amount {get ; set;}
    //     public DateTime DateTime {get ; set;} = DateTime.Now;
    //     public string Description {get ; set;}
    //     public string PropertyId {get ; set;}
    // }
}