using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Repository.Interfaces;

namespace RealEstateMvcApp.Models.Service.Interfaces.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        // public BaseResponse<Wallet> Add(Wallet wallet)
        // {
        //     var wallets = _walletRepository.Add(wallet);
        //     _walletRepository.Save();
        //     return new BaseResponse<Wallet>{
        //         Message = "Successful",
        //         Status = true
        //     };
        // }

        public BaseResponse<Wallet> FundWallet(string userId, double amount)
        {
            if (amount < 0)
            {
                return new BaseResponse<Wallet>{
                    Message = "Amount must be greater than zero",
                    Status = false
                };
                
            }
            var wallet = _walletRepository.GetByUserId(userId);
            wallet.Balance += amount;
            _walletRepository.Update(wallet); 
            _walletRepository.Save(); 
            return new BaseResponse<Wallet>{
                Message = "Successful",
                Status = true
            };
        }

        public BaseResponse<Wallet> Get(string id)
        {
            var wallet = _walletRepository.Get(w => w.UserId == id);
            if (wallet is not null)
            {
                return new BaseResponse<Wallet>{
                    Message = "Found",
                    Status = true,
                     Data = new Wallet()
                    {
                        Id = wallet.UserId,
                        Balance = wallet.Balance
                        // = manager.User.PhoneNumber,
                        // Address = manager.User.Address
                        
                    }
                };
            }
            return new BaseResponse<Wallet>{
                Message = "Not Found",
                Status = false
            };
        }

        public IEnumerable<Wallet> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Wallet> GetByUserId(string userId)
        {
            var wallet = _walletRepository.Get(w => w.UserId == userId);
            if (wallet is not null)
            {
                return new BaseResponse<Wallet>{
                    Message = "Found",
                    Status = true,
                    Data = wallet
                };
            }
            return new BaseResponse<Wallet>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<Wallet> Remove(string id)
        {
            var walletExist = _walletRepository.Get(id);
            if (walletExist is not null)
            {
                walletExist.IsDeleted = true;
                _walletRepository.Save();
                return new BaseResponse<Wallet>{
                    Message = "Removed Successfully",
                    Status = true
                };
            }
            return new BaseResponse<Wallet>{
                Message = "Not Found",
                Status = false
            };
            
        }

        
    }
}