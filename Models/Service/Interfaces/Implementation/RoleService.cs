using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Service.Interfaces.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }  
        public BaseResponse<RoleDto> Create(CreateRoleRequestModel model)
        {
            var role = _roleRepository.Get(c => c.Name == model.Name);
            if (role == null)
            {
                var roles = new Role();
                
                roles.Name = model.Name;
                roles.Description = model.Description;
                roles.CreatedBy = "Super Admin";
                
                _roleRepository.Create(roles);
                _roleRepository.save();
                 return new BaseResponse<RoleDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new RoleDto
                    {
                        Id = roles.Id,
                        Name = roles.Name,
                        Description = roles.Description
                    }
                };
                
            }
             return new BaseResponse<RoleDto>{
                     Message = "Role Already Exist",
                     Status = true
                 };
        }

        public BaseResponse<RoleDto> Delete(string id)
        {
            var clientExist = _roleRepository.Get(c => c.Id == id);
            if (clientExist is not null)
            {
                 clientExist.IsDeleted = true;
                _roleRepository.Update(clientExist);
                _roleRepository.save();

                return new BaseResponse<RoleDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<RoleDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<RoleDto> Get(string id)
        {
            var role = _roleRepository.Get(id);
            if (role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            return new BaseResponse<RoleDto>
            {
                Message = "Successful",
                Status = true,
                Data = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };

        }

        public BaseResponse<IEnumerable<RoleDto>> GetAll()
        {
            var role = _roleRepository.GetAll();
            if (role == null)
            {
                return new BaseResponse<IEnumerable<RoleDto>>
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Message = "Successful",
                Status = true,
                Data = role.Select(c => new RoleDto{
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
            };
        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model)
        {
             var role = _roleRepository.Get(id);
            if (role is null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Not found",
                    Status = false,
                };
            }

            role.Name = model.Name;
            role.Description = model.Description;
            _roleRepository.Update(role);
            _roleRepository.save();

            return new BaseResponse<RoleDto>
            {
                Message = "Successful",
                Status = true,
                Data = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }
    }
}