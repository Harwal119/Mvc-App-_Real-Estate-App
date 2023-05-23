
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Enums;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Service.Interfaces.Implementation;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IPropertyRepository _propertyRepository;
    private readonly IClientRepository _clientRepository;

    public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository, IPropertyRepository propertyRepository,IClientRepository clientRepository)

    {
        _transactionRepository = transactionRepository;
        _walletRepository = walletRepository;
        _propertyRepository = propertyRepository;
        _clientRepository = clientRepository;

    }
    public BaseResponse<TransactionDto> Create(string propertyId, string userId)
    {
        var property = _propertyRepository.Get(propertyId);
        if (property == null)
        {
            return new BaseResponse<TransactionDto>
            {
                Message = "Property not found",
                Status = false,
                Data = new TransactionDto{}
            };
        }
        property.Status = (Int32)Status.NotAvailableForRent;


        var client = _clientRepository.Get(c => c.UserId == userId);

        var transaction = new Transaction
        {
            Amount = property.Total,
            DateCreated = property.DateCreated,
            ClientId = client.Id,
            PropertyId = propertyId,
            Description = property.Description,
            CreatedBy = "Client"
        };

        var wallet = _walletRepository.Get(w => w.UserId == userId);
        wallet.Balance -= transaction.Amount;

        if (wallet.Balance < 0)
        {
            return new BaseResponse<TransactionDto>
            {
                Message = "Insuficient Balance",
                Status = false,
                Data = new TransactionDto{}
            };
        }


        _transactionRepository.Create(transaction);
        _transactionRepository.save();

        return new BaseResponse<TransactionDto>
        {
            Message = "Added Successful",
            Status = true,
            Data = new TransactionDto
            {

            }
        };
    }

    public BaseResponse<TransactionDto> Purchasing(string propertyId, string userId)
    {
        var property = _propertyRepository.Get(propertyId);
        if (property == null)
        {
            return new BaseResponse<TransactionDto>
            {
                Message = "Property not found",
                Status = false,
                Data = new TransactionDto{}
            };
        }
        property.Status = (Int32)Status.NotAvailableForpurchase;


        var client = _clientRepository.Get(c => c.UserId == userId);

        var transaction = new Transaction
        {
            Amount = property.Price + property.AgencyFee,
            DateCreated = property.DateCreated,
            ClientId = client.Id,
            PropertyId = propertyId,
            Description = property.Description,
            CreatedBy = "Client"
        };

        var wallet = _walletRepository.Get(w => w.UserId == userId);
        wallet.Balance -= transaction.Amount;

        if (wallet.Balance < 0)
        {
            return new BaseResponse<TransactionDto>
            {
                Message = "Insuficient Balance",
                Status = false,
                Data = new TransactionDto{}
            };
        }


        _transactionRepository.Create(transaction);
        _transactionRepository.save();

        return new BaseResponse<TransactionDto>
        {
            Message = "Added Successful",
            Status = true,
            Data = new TransactionDto
            {

            }
        };
    }



    public BaseResponse<TransactionDto> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public BaseResponse<TransactionDto> Get(string id)
    {
        throw new NotImplementedException();
    }

    public BaseResponse<IEnumerable<TransactionDto>> GetAll()
    {
        throw new NotImplementedException();
    }


}
