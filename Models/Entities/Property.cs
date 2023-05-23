using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Enums;

namespace RealEstateMvcApp.Models.Entities
{
    public class Property : BaseEntity
    {
        public string Name {get ; set;}
        public string Description {get ; set;}
        public string Location {get ; set;}
        public int TransactionType {get ; set;}
        public double Price {get ; set;}
        public int Status {get ; set;}
        public double AgencyFee {get ; set;}
        public double AgreementFee {get ; set;}
        public double CautionFee {get ; set;}
        public double Total {get ; set;}
        public string Photo {get ; set;}
        public string PropertyDocument {get ; set;}
        public string PrincipalId {get ; set;}
        public Principal Principal {get ; set;}
        public  List<Rental> Rentals {get ; set;}
        public List<PropertyClient> PropertyClients {get ; set;}
        public List<PropertyAgent> PropertyAgents {get ; set;}
        
    }
}