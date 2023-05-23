using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Dtos
{
    public class ClientDto
    {
        public string Id {get ; set;}
        public string Name {get ; set;}
        public string Email {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
        public string Picture {get ; set;}
        // public IEnumerable<PropertyDto> PropertyClients {get; set;}
        // public IEnumerable<RentalDto> Rentals {get; set;}
        // public IEnumerable<Purchase> Purchases {get; set;}

    }

    public class CreateClientRequestModel
    {
        
        public string Name {get ; set;}
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Please enter a valid email address")]
        public string Email {get ; set;}
        public string PassWord {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
        public IFormFile Picture {get ; set;}
        
    }

    public class UpdateClientRequestModel
    {
        public string Name {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
    
    }
}