using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface ITransactionService
    {
        public BaseResponse<TransactionDto> Create(string propertyId, string userId);
        // public BaseResponse<TransactionDto> Update( string id ,UpdatePropertyRequestModel model);
        public BaseResponse<TransactionDto> Purchasing(string propertyId, string userId);
        public BaseResponse<TransactionDto> Delete( string id );
        public BaseResponse<TransactionDto> Get( string id );
        public BaseResponse<IEnumerable<TransactionDto>> GetAll();
    }
}