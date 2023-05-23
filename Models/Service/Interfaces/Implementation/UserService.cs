using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Repository;

namespace RealEstateMvcApp.Models.Service.Interfaces.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public BaseResponse<UserDto> Get(string id)
        {
            var user = _userRepository.Get(id);
            if (user is not null)
            {
                return new BaseResponse<UserDto>{
                    Message = "Found",
                    Status = true,
                    Data = new UserDto{
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber
                    }
                };
            }
            return new BaseResponse<UserDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<UserDto>> GetAll()
        {
            var user = _userRepository.GetAll();
            if (user is not null)
            {
                return new BaseResponse<IEnumerable<UserDto>>{
                    Message = "Found",
                    Status = true,
                    Data = user.Select(c => new UserDto{
                        Id = c.Id,
                        Name = c.Name,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber
                    
                    }).ToList()
                    

                };
            }
            return new BaseResponse<IEnumerable<UserDto>>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<UserDto> Login(LoginRequestModel model)
        {
            var user = _userRepository.Get(a => a.Email == model.Email && a.Password == model.PassWord);
            if (user != null)
            {
                var userLogin = new BaseResponse<UserDto>
                {
                    Message = "Login Successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.UserRoles.Select(a => new RoleDto{
                             Id = a.Role.Id,
                             Name = a.Role.Name,
                             Description = a.Role.Description
                         }).ToList(),
                        
                    }
                };
                return userLogin;

            }
            return new BaseResponse<UserDto>
            {
                Message = "Incorrect email or password",
                Status = false
            };
        }
    }
}