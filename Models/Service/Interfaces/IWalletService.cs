using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;

namespace RealEstateMvcApp.Models.Service.Interfaces
{
    public interface IWalletService
    {
        BaseResponse<Wallet> Get(string id);
        BaseResponse<Wallet> FundWallet(string userId , double amount);
        BaseResponse<Wallet> GetByUserId(string userId);
        // BaseResponse<Wallet> Add(Wallet wallet);
        BaseResponse<Wallet> Remove(string id);
        IEnumerable<Wallet> GetAll();
    }
}