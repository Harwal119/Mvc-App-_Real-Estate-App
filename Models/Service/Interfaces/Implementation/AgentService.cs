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
    public class AgentService : IAgentService
    {
        public readonly IAgentRepository _agentRepository;
        public readonly IUserRepository _userRepository;
        public readonly IRoleRepository _roleRepository;
        public readonly IWalletRepository _walletRepository;
        public AgentService(IAgentRepository agentRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWalletRepository walletRepository)
        {
            _agentRepository = agentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _walletRepository = walletRepository;
        }
        public BaseResponse<AgentDto> Create(CreateAgentRequestModel model)
        {
             var agentExist = _userRepository.Get(c => c.Email == model.Email);
            if (agentExist != null)
            {
                return new BaseResponse<AgentDto>{
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

             var role = _roleRepository.Get(r => r.Name == "Agent");

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
                var agent = new Agent();
                 agent.UserId = user.Id;
                 agent.CreatedBy = "Manger";
                 _agentRepository.Create(agent);
                 _walletRepository.Add(wallet);
                 _agentRepository.save();
                 
                  return new BaseResponse<AgentDto>{
                     Message = "Added Successfully",
                     Status = true,
                     Data = new AgentDto{
                     Id = agent.User.Id,
                     Name = agent.User.Name,
                     Email = agent.User.Email,
                     PhoneNumber = agent.User.PhoneNumber,
                     Address = agent.User.Address
                    }
                };
        }

        public BaseResponse<AgentDto> Delete(string id)
        {
            var agentExist = _agentRepository.Get(c => c.Id == id);
            if (agentExist is not null)
            {
                 agentExist.IsDeleted = true;
                _agentRepository.Update(agentExist);
                _agentRepository.save();

                return new BaseResponse<AgentDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<AgentDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<AgentDto> Get(string id)
        {
            var agent = _agentRepository.Get(id);
            if (agent is not null)
            {
                return new BaseResponse<AgentDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new AgentDto()
                    {
                        Name = agent.User.Name,
                        Email = agent.User.Email,
                        PhoneNumber = agent.User.PhoneNumber,
                        Address = agent.User.Address
                        
                    }
                };
            }
            return new BaseResponse<AgentDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<AgentDto>> GetAll()
        {
            var agent = _agentRepository.GetAll();
            if (agent is not null)
            {
                return new BaseResponse<IEnumerable<AgentDto>>{
                    Message = "Found",
                    Status = true,
                    Data = agent.Select(c => new AgentDto{
                        Id = c.Id,
                        Name = c.User.Name,
                        Email = c.User.Email,
                        PhoneNumber = c.User.PhoneNumber,
                        Address = c.User.Address 
                    })
                    

                };
            }
            return new BaseResponse<IEnumerable<AgentDto>>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<AgentDto> Update(string id, UpdateAgentRequestModel model)
        {
            var agent = _agentRepository.Get(id);
            if (agent is not null)
            {
               agent.User.Name = model.Name;
               agent.User.PhoneNumber = model.PhoneNumber;
               agent.User.Address = model.Address;
               _agentRepository.Update(agent);
               _agentRepository.save();
               
               return new BaseResponse<AgentDto>{
                Message = "Update Successful",
                Status = true,
                Data = new AgentDto{
                    Name = agent.User.Name,
                    PhoneNumber = agent.User.PhoneNumber,
                    Address = agent.User.Address
                }
            
               };
            }
            return new BaseResponse<AgentDto>{
                Message = "Not Found",
                Status = false
            };

        }
    }
}