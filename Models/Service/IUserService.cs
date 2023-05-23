using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service
{
    public interface IUserService
    {
        public BaseResponse<UserDto> Login(LoginRequestModel model);
        public BaseResponse<UserDto> Get(string id);
        public BaseResponse<IEnumerable<UserDto>> GetAll();

    }
}