using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IRoleService
    {
        public BaseResponse<RoleDto> Create(CreateRoleRequestModel model);
        public BaseResponse<RoleDto> Update( string id ,UpdateRoleRequestModel model);
        public BaseResponse<RoleDto> Delete( string id );
        public BaseResponse<RoleDto> Get( string id );
        public BaseResponse<IEnumerable<RoleDto>> GetAll();
    }
}