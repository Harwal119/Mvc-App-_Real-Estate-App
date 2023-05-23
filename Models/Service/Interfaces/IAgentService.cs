using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IAgentService 
    {
        public BaseResponse<AgentDto> Create(CreateAgentRequestModel model);
        public BaseResponse<AgentDto> Update( string id ,UpdateAgentRequestModel model);
        public BaseResponse<AgentDto> Delete( string id );
        public BaseResponse<AgentDto> Get( string id );
        public BaseResponse<IEnumerable<AgentDto>> GetAll();

    }
}