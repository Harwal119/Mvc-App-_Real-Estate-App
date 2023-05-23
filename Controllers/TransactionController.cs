using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Service.Interfaces;

namespace RealEstateMvcApp.Controllers
{
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var transaction = _transactionService.Create(id, userId);
            TempData["message"] = transaction.Message;
            if (transaction.Status)
            {
                return RedirectToAction("List" , "Property");
            }
            return RedirectToAction("Client","User");
           
            return View();
        }

        public IActionResult Purchasing(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var transaction = _transactionService.Purchasing(id, userId);
            TempData["message"] = transaction.Message;
            if (transaction.Status)
            {
                return RedirectToAction("List" , "Property");
            }
            return RedirectToAction("Client","User");
           
            return View();
        }


          
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}