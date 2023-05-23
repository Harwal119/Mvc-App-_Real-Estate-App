using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Enums;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Service.Interfaces.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IWalletRepository _walletRepository;

        public PropertyService(IWebHostEnvironment webHostEnvironment, IPropertyRepository propertyRepository, IWalletRepository walletRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _propertyRepository = propertyRepository;
            _walletRepository = walletRepository;
        }

        public BaseResponse<PropertyDto> Create(CreatePropertyRequestModel model)
        {
            var property = _propertyRepository.Get(c => c.Name == model.Name);
            if (property == null)
            {
                var Photo = UploadFile(model.Photo);
                var PropertyDocument = UploadFile(model.PropertyDocument);

                var propertys = new Property
                {
                    Name = model.Name,
                    Location = model.Location,
                    Description = model.Description,
                    TransactionType = model.TransactionType,
                    Price = model.Price,
                    Status = model.Status,
                    Photo = Photo,
                    PropertyDocument = PropertyDocument,
                    PrincipalId = model.PrincipalId,
                    CreatedBy = "Manager",
                    AgencyFee = 0.1 * model.Price,
                    AgreementFee = 0.1 * model.Price,
                    CautionFee = 0.05 * model.Price,
                };
                propertys.Total = propertys.CautionFee + propertys.AgencyFee + propertys.AgreementFee + propertys.Price;

                _propertyRepository.Create(propertys);
                _propertyRepository.save();
                return new BaseResponse<PropertyDto>
                {
                    Message = "Added Successful",
                    Status = true,
                    Data = new PropertyDto
                    {
                        Id = propertys.Id,
                        Name = propertys.Name,
                        Location = propertys.Location,
                        Description = propertys.Description,
                        TransactionType = (TransactionType)propertys.TransactionType,
                        Price = propertys.Price,
                        Status = (Status)propertys.Status
                    }
                };
            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Already Exist",
                Status = false
            };

        }

        public BaseResponse<PropertyDto> Delete(string id)
        {
            var propertyExist = _propertyRepository.Get(c => c.Id == id);
            if (propertyExist is not null)
            {
                propertyExist.IsDeleted = true;
                _propertyRepository.Update(propertyExist);
                _propertyRepository.save();

                return new BaseResponse<PropertyDto>
                {
                    Message = "Successful",
                    Status = true
                };
            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<PropertyDto> Get(string id)
        {
            var property = _propertyRepository.Get(id);
            if (property is not null)
            {


                double price = property.Price;
                double fee = 0.1 * price;
                double agencyFee = fee;
                double agreementFee = fee;
                double cautionFee = 0.05 * price;
                double total = cautionFee + agencyFee + agreementFee + price;


                return new BaseResponse<PropertyDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new PropertyDto
                    {
                        // Id = property.Id,
                        Name = property.Name,
                        Description = property.Description,
                        Location = property.Location,
                        TransactionType = (TransactionType)property.TransactionType,
                        Price = property.Price,
                        AgencyFee = agencyFee,
                        AgreementFee = agreementFee,
                        CautionFee = cautionFee,
                        Total = total,
                        Status = (Status)property.Status
                    }

                };
            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<PropertyDto>> GetAll()
        {
            var property = _propertyRepository.GetAll();
            if (property is not null)
            {
                return new BaseResponse<IEnumerable<PropertyDto>>
                {
                    Message = "Found",
                    Status = true,
                    Data = property.Select(s => new PropertyDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Description = s.Description,
                        Location = s.Location,
                        TransactionType = (TransactionType)s.TransactionType,
                        Price = s.Price,
                        Status = (Status)s.Status

                    })
                };
            }
            return new BaseResponse<IEnumerable<PropertyDto>>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<PropertyDto>> GetAllAvailable()
        {
            var property = _propertyRepository.GetAllAvailable();
            if (property is not null)
            {
                return new BaseResponse<IEnumerable<PropertyDto>>
                {
                    Message = "Found",
                    Status = true,
                    Data = property.Select(s => new PropertyDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Description = s.Description,
                        Location = s.Location,
                        TransactionType = (TransactionType)s.TransactionType,
                        Price = s.Price,
                        Status = (Status)s.Status

                    })
                };
            }
            return new BaseResponse<IEnumerable<PropertyDto>>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<PropertyDto> Update(string id, UpdatePropertyRequestModel model)
        {
            var propertyExist = _propertyRepository.Get(id);
            if (propertyExist is not null)
            {
                propertyExist.Name = model.Name;
                propertyExist.TransactionType = model.TransactionType;
                propertyExist.Price = model.Price;
                propertyExist.Status = model.Status;
                _propertyRepository.Update(propertyExist);
                _propertyRepository.save();
                return new BaseResponse<PropertyDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new PropertyDto
                    {
                        Name = propertyExist.Name,
                        TransactionType = (TransactionType)propertyExist.TransactionType,
                        Price = propertyExist.Price
                    }
                };

            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Not Found",
                Status = false
            };
        }
        public BaseResponse<PropertyDto> RentProperty(string id)
        {
            var property = _propertyRepository.Get(id);
            var wallet = _walletRepository.Get(id);


            double price = property.Price;
            double fee = 0.1 * price;
            double agencyFee = fee;
            double agreementFee = fee;
            double cautionFee = 0.05 * price;
            double total = cautionFee + agencyFee + agreementFee + price;

            if ((double)wallet.Balance > total)
            {
                wallet.Balance -= total;
                property.Status = (int)Status.NotAvailableForRent;

                return new BaseResponse<PropertyDto>
                {
                    Message = "Rented Successful",
                    Status = true,
                    Data = new PropertyDto
                    {
                        Name = property.Name,
                        Description = property.Description,
                        Location = property.Location,
                        TransactionType = (TransactionType)property.TransactionType,
                        Price = property.Price,
                        AgencyFee = agencyFee,
                        AgreementFee = agreementFee,
                        CautionFee = cautionFee,
                        Total = total,
                        Status = (Status)property.Status
                    }
                };
            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Not Found",
                Status = false
            };


        }

        public BaseResponse<PropertyDto> PurchaseProperty(string id)
        {
            var property = _propertyRepository.Get(id);
            var wallet = _walletRepository.Get(id);


            double price = property.Price;
            double fee = 0.1 * price;
            double agencyFee = fee;
            double total = agencyFee + price;

            if (wallet.Balance > total)
            {
                wallet.Balance -= total;
                property.Status = (int)Status.NotAvailableForpurchase;
                _walletRepository.Update(wallet);
                _propertyRepository.Update(property);
                _propertyRepository.save();

                return new BaseResponse<PropertyDto>
                {
                    Message = "Purchased Successful",
                    Status = true,
                    Data = new PropertyDto
                    {
                        Name = property.Name,
                        Description = property.Description,
                        Location = property.Location,
                        TransactionType = (TransactionType)property.TransactionType,
                        Price = property.Price,
                        AgencyFee = agencyFee,
                        Total = total,
                        Status = (Status)property.Status
                    }
                };
            }
            return new BaseResponse<PropertyDto>
            {
                Message = "Not Found",
                Status = false
            };


        }


        private string UploadFile(IFormFile file)
        {
            var appUploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Upload/images");
            if (!Directory.Exists(appUploadPath))
            {
                Directory.CreateDirectory(appUploadPath);
            }
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(appUploadPath, fileName);
            file.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}