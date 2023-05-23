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
    public class PrincipalService : IPrincipalService
    {
        public readonly IPrincipalRepository _principalRepository;
        public readonly IUserRepository _userRepository;
        public readonly IRoleRepository _roleRepository;
        public readonly IWalletRepository _walletRepository;
        public PrincipalService(IPrincipalRepository principalRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWalletRepository walletRepository)
        {
            _principalRepository = principalRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _walletRepository = walletRepository;
        }
        public BaseResponse<PrincipalDto> Create(CreatePrincipalRequestModel model)
        {
            var principalExist = _userRepository.Get(c => c.Email == model.Email);
            if (principalExist != null)
            {
                 return new BaseResponse<PrincipalDto>{
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
             user.CreatedBy  = "Super Admin";

             var role = _roleRepository.Get(r => r.Name == "Principal");

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
                var principal = new Principal();
                 principal.UserId = user.Id;
                 principal.CreatedBy = "Super Admin"; 
                 _principalRepository.Create(principal);
                 _walletRepository.Add(wallet);
                 _principalRepository.save();
                 
                  return new BaseResponse<PrincipalDto>{
                     Message = "Added Successfully",
                     Status = true,
                     Data = new PrincipalDto{
                     Id = principal.User.Id,
                     Name = principal.User.Name,
                     Email = principal.User.Email,
                     PhoneNumber = principal.User.PhoneNumber,
                     Address = principal.User.Address
                    }
                };
        }

        public BaseResponse<PrincipalDto> Delete(string id)
        {
             var principalExist = _principalRepository.Get(c => c.Id == id);
            if (principalExist is not null)
            {
                 principalExist.IsDeleted = true;
                _principalRepository.Update(principalExist);
                _principalRepository.save();

                return new BaseResponse<PrincipalDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<PrincipalDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<PrincipalDto> Get(string id)
        {
            var principal = _principalRepository.Get(id);
            if (principal is not null)
            {
                return new BaseResponse<PrincipalDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new PrincipalDto()
                    {
                        Name = principal.User.Name,
                        Email = principal.User.Email,
                        PhoneNumber = principal.User.PhoneNumber,
                        Address = principal.User.Address
                        
                    }
                };
            }
            return new BaseResponse<PrincipalDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<PrincipalDto>> GetAll()
        {
            var principal = _principalRepository.GetAll();
            if (principal is not null)
            {
                return new BaseResponse<IEnumerable<PrincipalDto>>{
                    Message = "Found",
                    Status = true,
                    Data = principal.Select(c => new PrincipalDto{
                        Id = c.Id,
                        Name = c.User.Name,
                        Email = c.User.Email,
                        PhoneNumber = c.User.PhoneNumber,
                        Address = c.User.Address 
                    })
                    

                };
            }
            return new BaseResponse<IEnumerable<PrincipalDto>>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<PrincipalDto> Update(string id, UpdatePrincipalRequestModel model)
        {
            var principal = _principalRepository.Get(id);
            if (principal is not null)
            {
               principal.User.Name = model.Name;
               principal.User.PhoneNumber = model.PhoneNumber;
               principal.User.Address = model.Address;
               _principalRepository.Update(principal);
               _principalRepository.save();
               
               return new BaseResponse<PrincipalDto>{
                Message = "Update Successful",
                Status = true,
                Data = new PrincipalDto{
                    Name = principal.User.Name,
                    PhoneNumber = principal.User.PhoneNumber,
                    Address = principal.User.Address
                }
            
               };
            }
            return new BaseResponse<PrincipalDto>{
                Message = "Not Found",
                Status = false
            };
        }
    }
}