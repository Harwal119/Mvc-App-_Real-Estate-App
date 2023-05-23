using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IPropertyService
    {
        public BaseResponse<PropertyDto> Create(CreatePropertyRequestModel model);
        public BaseResponse<PropertyDto> Update( string id ,UpdatePropertyRequestModel model);
        public BaseResponse<PropertyDto> Delete( string id );
        public BaseResponse<PropertyDto> Get( string id );
        public BaseResponse<IEnumerable<PropertyDto>> GetAll();
        public BaseResponse<IEnumerable<PropertyDto>> GetAllAvailable();
        public BaseResponse<PropertyDto> RentProperty(string id);

    }
}