using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IClientService
    {
        public BaseResponse<ClientDto> Create(CreateClientRequestModel model);
        public BaseResponse<ClientDto> Update( string id ,UpdateClientRequestModel model);
        public BaseResponse<ClientDto> Delete( string id );
        public BaseResponse<ClientDto> Get( string id );
        public BaseResponse<IEnumerable<ClientDto>> GetAll();

    }
}