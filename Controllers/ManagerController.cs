using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Repository.Interfaces;
using RealEstateMvcApp.Models.Service.Interfaces;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(CreateManagerRequestModel model)
        {
            var manager = _managerService.Create(model);
            if(manager is not null)
            {
                TempData["success"] = "Created Successfully";
            } 
            return RedirectToAction("List");
        }
        [Authorize]

        public IActionResult List()
        {
           var manager = _managerService.GetAll();
            return View(manager.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var manager = _managerService.Get(id);
            return View(manager.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
           _managerService.Delete(id);
            return RedirectToAction("List");
        }
        // [HttpGet]
        // public IActionResult Delete(string id)
        // {
        //     var manager = _managerService.Get(id);
        //     return View(manager.Data);
        // }
        // [HttpPost, ActionName("Delete")]
        // public IActionResult softDelete(string id)
        // {
        //     return View();
        // }
        [Authorize]
        [HttpGet]
         public IActionResult Edit(string id)
        {
            var manager = _managerService.Get(id);
            var updateRole = new UpdateManagerRequestModel()
            {
                Name = manager.Data.Name,
                PhoneNumber = manager.Data.PhoneNumber,
                Address = manager.Data.Address,

            };
            return View(updateRole);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdateManagerRequestModel model)
        {
            _managerService.Update(id,model);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var client = _managerService.Get(id);
            return View(client.Data);
        }
    }
}