using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Service.Interfaces;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Register(CreateClientRequestModel model)
        {
            var client = _clientService.Create(model);
            TempData["message"] = client.Message;
            if (client.Status)
            {
                return RedirectToAction("Login" , "User");
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var client = _clientService.Get(id);
            return View(client.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var client = _clientService.Get(id);
            return View(client.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
           _clientService.Delete(id);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var client = _clientService.Get(id);
            var updateRole = new UpdateClientRequestModel()
            {
                Name = client.Data.Name,
                PhoneNumber = client.Data.PhoneNumber,
                Address = client.Data.Address,

            };
            return View(updateRole);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdateClientRequestModel model)
        {
            _clientService.Update(id,model);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            var client = _clientService.GetAll();
            return View(client.Data);
        }
        
    }
}