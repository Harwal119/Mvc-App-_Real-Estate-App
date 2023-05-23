using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Enums;

namespace RealEstateMvcApp.Models.Dtos
{
    public class PropertyDto
    {
        public string Id {get ; set;}
        public string Name {get ; set;}
        public string Description {get ; set;}
        public string Location {get ; set;}
        public TransactionType TransactionType {get ; set;}
        public double Price {get ; set;}
        public double AgencyFee {get ; set;}
        public double AgreementFee {get ; set;}
        public double CautionFee {get ; set;}
        public double Total {get ; set;}
        public Status Status {get ; set;}
         public IFormFile Photo { get; set; }
         public IFormFile PropertyDocument { get; set; }
        public string PrincipalId {get ; set;}
        public Principal Principal {get ; set;}
        // public  List<RentalDto> Rentals {get ; set;}
        public List<ClientDto> Clients {get ; set;}
        // public List<AgentDto> Agents {get ; set;}
    }

    public class CreatePropertyRequestModel
    {
        public string Name {get ; set;}
        public string Description {get ; set;}
        public string Location {get ; set;}
        public int TransactionType {get ; set;}
        public double Price {get ; set;}
        public int Status {get ; set;}
         public IFormFile Photo { get; set; }
         public IFormFile PropertyDocument { get; set; }
        public string PrincipalId {get ; set;}
        
    }
    public class UpdatePropertyRequestModel
    {
        public string Name {get ; set;}
        public int TransactionType {get ; set;}
        public double Price {get ; set;}
        public int Status {get ; set;}

        

    }
}