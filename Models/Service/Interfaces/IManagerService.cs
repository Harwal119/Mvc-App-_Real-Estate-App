using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IManagerService 
    {
        public BaseResponse<ManagerDto> Create(CreateManagerRequestModel model);
        public BaseResponse<ManagerDto> Update( string id ,UpdateManagerRequestModel model);
        public BaseResponse<ManagerDto> Delete( string id );
        public BaseResponse<ManagerDto> Get( string id );
        public BaseResponse<IEnumerable<ManagerDto>> GetAll();

    }
}