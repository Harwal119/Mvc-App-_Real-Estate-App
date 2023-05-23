using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Dtos
{
    public class UserDto
    {
        public string Id  {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get; set;}
        public double Wallet {get;set;}
        public ICollection<RoleDto> Roles {get ; set;} 
    }

    public class LoginRequestModel
    {
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Please enter a valid email address")]
        public string Email {get ; set;}
        public string PassWord {get ; set;}
    }
}