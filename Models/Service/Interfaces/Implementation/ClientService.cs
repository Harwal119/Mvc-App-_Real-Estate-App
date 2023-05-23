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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ClientService(IClientRepository clientRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWalletRepository walletRepository,IWebHostEnvironment webHostEnvironment)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _walletRepository = walletRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public BaseResponse<ClientDto> Create(CreateClientRequestModel model)
        {
            var clientExist = _userRepository.Get(c => c.Email == model.Email);
            if (clientExist != null)
            {
                return new BaseResponse<ClientDto>{
                    Message = "Aready exist",
                    Status = false
                };     
            }
           
            var Picture = UploadFile(model.Picture);
             var user = new User();
             user.Name = model.Name;
             user.Email = model.Email;
             user.Password = model.PassWord;
             user.PhoneNumber = model.PhoneNumber;
             user.Address = model.Address;
             user.CreatedBy = "Super Admin";

             var role = _roleRepository.Get(r => r.Name == "Client");

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
                var client = new Client();
                 client.Picture = Picture;
                 client.UserId = user.Id;
                 client.CreatedBy = "Super Admin";
                 _clientRepository.Create(client);
                 _walletRepository.Add(wallet);
                 _clientRepository.save();
                 
                  return new BaseResponse<ClientDto>{
                     Message = "Added Successfully",
                     Status = true,
                     Data = new ClientDto{
                     Id = client.User.Id,
                     Name = client.User.Name,
                     Email = client.User.Email,
                     PhoneNumber = client.User.PhoneNumber,
                     Address = client.User.Address
                    }
                };
        }

        public BaseResponse<ClientDto> Delete(string id)
        {
            var clientExist = _clientRepository.Get(c => c.Id == id);
            if (clientExist is not null)
            {
                 clientExist.IsDeleted = true;
                _clientRepository.Update(clientExist);
                _clientRepository.save();

                return new BaseResponse<ClientDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<ClientDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<ClientDto> Get(string id)
        {
            var client = _clientRepository.Get(v => v.UserId == id);
            if (client is not null)
            {
                return new BaseResponse<ClientDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new ClientDto()
                    {
                        Name = client.User.Name,
                        Email = client.User.Email,
                        PhoneNumber = client.User.PhoneNumber,
                        Address = client.User.Address,
                        Picture = client.Picture
                        
                    }
                };
            }
            return new BaseResponse<ClientDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<ClientDto>> GetAll()
        {
            var client = _clientRepository.GetAll();
            if (client is not null)
            {
                return new BaseResponse<IEnumerable<ClientDto>>{
                    Message = "Found",
                    Status = true,
                    Data = client.Select(c => new ClientDto{
                        Id = c.Id,
                        Name = c.User.Name,
                        PhoneNumber = c.User.PhoneNumber,
                        Address = c.User.Address 
                    })
                    

                };
            }
            return new BaseResponse<IEnumerable<ClientDto>>{
                Message = "Not Found",
                Status = false
            };

        }

        public BaseResponse<ClientDto> Update(string id, UpdateClientRequestModel model)
        {
            var client = _clientRepository.Get(id);
            if (client is not null)
            {
               client.User.Name = model.Name;
               client.User.PhoneNumber = model.PhoneNumber;
               client.User.Address = model.Address;
               _clientRepository.Update(client);
               _clientRepository.save();
               
               return new BaseResponse<ClientDto>{
                Message = "Update Successful",
                Status = true,
                Data = new ClientDto{
                    Name = client.User.Name,
                    PhoneNumber = client.User.PhoneNumber,
                    Address = client.User.Address
                }
            
               };
            }
            return new BaseResponse<ClientDto>{
                Message = "Not Found",
                Status = false
            };


    
        }
        private string UploadFile(IFormFile file)
        {
            var pictureUploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"Picture");
            if (!Directory.Exists(pictureUploadPath))
            {
                Directory.CreateDirectory(pictureUploadPath);
            }
            var fileName = Guid.NewGuid().ToString() +"_"+ file.FileName;
            var fullPath = Path.Combine(pictureUploadPath, fileName);
            file.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}