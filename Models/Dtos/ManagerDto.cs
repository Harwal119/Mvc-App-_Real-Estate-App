using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Dtos
{
    public class ManagerDto
    {
        public string Id {get ; set;}
        public string Name {get ; set;}
        public string Email {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
        public string UserId {get ; set;}
        public User User {get ; set;}
    }

    public class CreateManagerRequestModel
    {
        public string Name {get ; set;}
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Please enter a valid email address")]
        public string Email {get ; set;}
        public string PassWord {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
    }

    public class UpdateManagerRequestModel
    {
        public string Name {get ; set;}
        public string PhoneNumber {get ; set;}
        public string Address {get ; set;}
    }
}