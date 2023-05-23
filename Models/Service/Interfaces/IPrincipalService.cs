using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IPrincipalService
    {
        public BaseResponse<PrincipalDto> Create(CreatePrincipalRequestModel model);
        public BaseResponse<PrincipalDto> Update( string id ,UpdatePrincipalRequestModel model);
        public BaseResponse<PrincipalDto> Delete( string id );
        public BaseResponse<PrincipalDto> Get( string id );
        public BaseResponse<IEnumerable<PrincipalDto>> GetAll();
    }
}