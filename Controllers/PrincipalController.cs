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
    public class PrincipalController : Controller
    {
        private readonly IPrincipalService _principalService;

        public PrincipalController(IPrincipalService principalService)
        {
            _principalService = principalService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(CreatePrincipalRequestModel model)
        {
           var principal = _principalService.Create(model);
           if (principal is not null)
           {
                TempData["success"] = "Created Successfully";
           }
            return RedirectToAction("List");
        }
        [Authorize]
         public IActionResult List()
        {
           var principal = _principalService.GetAll();
            return View(principal.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var principal = _principalService.Get(id);
            return View(principal.Data);
        }
        [Authorize]
        [HttpGet]
         public IActionResult Edit(string id)
        {
            var principal = _principalService.Get(id);
            var updateRole = new UpdatePrincipalRequestModel()
            {
                Name = principal.Data.Name,
                PhoneNumber = principal.Data.PhoneNumber,
                Address = principal.Data.Address,

            };
            return View(updateRole);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdatePrincipalRequestModel model)
        {
            _principalService.Update(id,model);
            return RedirectToAction("List");
        }


        
    }
}