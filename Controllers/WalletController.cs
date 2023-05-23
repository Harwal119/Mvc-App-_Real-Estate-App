using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletRepository)
        {
            _walletService = walletRepository;
        }
        [Authorize]
        [HttpGet]
        public IActionResult FundWallet(string id)
        {
           var wallet = _walletService.GetByUserId(id);
            return View(wallet.Data);
        }
        [Authorize]
        [HttpPost]
        public IActionResult FundWallet(string id, double amount)
        {
           if (amount <= 0)
           {
                 ModelState.AddModelError("Amount", "amount must be greater than zero");
                // new BaseResponse<Wallet>{
                //     Message = "Amount must be greater than Zero"
                // };
           }
           if (ModelState.IsValid)
           {
                 _walletService.FundWallet(id, amount);
                return RedirectToAction("List","Property");
           }
           else
           {
            var wallet = _walletService.GetByUserId(id);
            return View(wallet.Data);
           }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Get(string id)
        {
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var wallet = _walletService.Get(id);
            return View(wallet.Data);
        }
    }
        
}