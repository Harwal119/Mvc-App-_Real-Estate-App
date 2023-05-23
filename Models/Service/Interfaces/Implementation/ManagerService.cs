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
    public class ManagerService : IManagerService
    {
        public readonly IManagerRepository _managerRepository;
        public readonly IUserRepository _userRepository;
        public readonly IRoleRepository _roleRepository;
         public readonly IWalletRepository _walletRepository;
        public ManagerService(IManagerRepository managerRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWalletRepository walletRepository)
        {
             _managerRepository = managerRepository;
             _userRepository = userRepository;
             _roleRepository = roleRepository;
             _walletRepository = walletRepository;
        }
        public BaseResponse<ManagerDto> Create(CreateManagerRequestModel model)
        {
            var managerExist = _userRepository.Get(c => c.Email == model.Email);
            if (managerExist != null)
            {
                 return new BaseResponse<ManagerDto>{
                Message = "Aready exist",
                Status = false
                };     
            }
            
             var user = new User();
             user.Name = model.Name;
             user.Email = model.Email;
             user.Password = model.PassWord;
             user.PhoneNumber = model.PhoneNumber;
             user.Address = model.Address;
             user.CreatedBy = "Super Admin";

             var role = _roleRepository.Get(r => r.Name == "Manager");

             var userRole = new UserRole{
                RoleId = role.Id,
                UserId = user.Id,
                Role = role,
                User = user,
                CreatedBy = "Super Admin"
            };
            
            var wallet = new Wallet{
                Balance = 0,
                UserId = user.Id,
                User = user,
                IsDeleted = false
            };
                user.UserRoles.Add(userRole);
                _userRepository.Create(user);
                var manager = new Manager();
                 manager.UserId = user.Id;
                 manager.CreatedBy = "Super Admin";
                 _managerRepository.Create(manager);
                 _walletRepository.Add(wallet);
                 _managerRepository.save();
                 
                  return new BaseResponse<ManagerDto>{
                     Message = "Added Successfully",
                     Status = true,
                     Data = new ManagerDto{
                     Id = manager.User.Id,
                     Name = manager.User.Name,
                     Email = manager.User.Email,
                     PhoneNumber = manager.User.PhoneNumber,
                     Address = manager.User.Address
                    }
                };
        }

        public BaseResponse<ManagerDto> Delete(string id)
        {
            var managerExist = _managerRepository.Get(c =>c.Id == id);
            if (managerExist is not null)
            {
                 managerExist.IsDeleted = true;
                _managerRepository.Update(managerExist);
                _managerRepository.save();

                return new BaseResponse<ManagerDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<ManagerDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<ManagerDto> Get(string id)
        {
            var manager = _managerRepository.Get(id);
            if (manager is not null)
            {
                return new BaseResponse<ManagerDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new ManagerDto()
                    {
                        Id = manager.User.Id,
                        Name = manager.User.Name,
                        Email = manager.User.Email,
                        PhoneNumber = manager.User.PhoneNumber,
                        Address = manager.User.Address
                        
                    }
                };
            }
            return new BaseResponse<ManagerDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<ManagerDto>> GetAll()
        {
            var manager = _managerRepository.GetAll();
            if (manager is not null)
            {
                return new BaseResponse<IEnumerable<ManagerDto>>{
                    Message = "Found",
                    Status = true,
                    Data = manager.Select(c => new ManagerDto{
                        Id = c.Id,
                        Name = c.User.Name,
                        Email = c.User.Email,
                        PhoneNumber = c.User.PhoneNumber,
                        Address = c.User.Address 
                    })
                    

                };
            }
            return new BaseResponse<IEnumerable<ManagerDto>>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<ManagerDto> Update(string id, UpdateManagerRequestModel model)
        {
            var manager = _managerRepository.Get(id);
            if (manager is not null)
            {
               manager.User.Name = model.Name;
               manager.User.PhoneNumber = model.PhoneNumber;
               manager.User.Address = model.Address;
               _managerRepository.Update(manager);
               _managerRepository.save();
               
               return new BaseResponse<ManagerDto>{
                Message = "Update Successful",
                Status = true,
                Data = new ManagerDto{
                    Name = manager.User.Name,
                    PhoneNumber = manager.User.PhoneNumber,
                    Address = manager.User.Address
                }
            
               };
            }
            return new BaseResponse<ManagerDto>{
                Message = "Not Found",
                Status = false
            };
        }
    }
}