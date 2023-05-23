using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Service.Interfaces;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IPrincipalService _principalService;
        private readonly IWalletService _walletService;

        public PropertyController(IPropertyService propertyService, IPrincipalService principalService, IWalletService walletService)
        {
            _propertyService = propertyService;
            _principalService = principalService;
            _walletService = walletService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            var principal = _principalService.GetAll();
            ViewBag.principal = principal.Data;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(CreatePropertyRequestModel model)
        {

            if(ModelState.IsValid)
            {
                var property = _propertyService.Create(model);

                if (property.Status)
                {
                    TempData["success"] = "Created Successfully";
                    // return View("List");
                    return RedirectToAction("List");
                }
            }

           
            var principal = _principalService.GetAll();
            ViewBag.principal = principal.Data;
            return RedirectToAction("List");
        }

        [Authorize]
        public IActionResult List()
        {
            // TempData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = _propertyService.GetAllAvailable();
            return View(response.Data);
        }
        [Authorize]
        public IActionResult ListA()
        {
            // TempData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = _propertyService.GetAll();
            return View(response.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var property = _propertyService.Get(id);
            return View(property.Data);
        }
        // [HttpGet]
        // public IActionResult Delete(string id)
        // {
        //     var property = _propertyService.Get(id);
        //     return View(property.Data);
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
            var property = _propertyService.Get(id);
            var updateProperty = new UpdatePropertyRequestModel()
            {
                Name = property.Data.Name,
                TransactionType = (int)property.Data.TransactionType,
                Price = property.Data.Price,
                Status = (int)property.Data.Status

            };
            return View(updateProperty);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdatePropertyRequestModel model)
        {
            _propertyService.Update(id,model);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var property = _propertyService.Get(id);
            return View(property.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
           _propertyService.Delete(id);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Rent( string id)
        {
            var property = _propertyService.Get(id);
            var wallet = _walletService.Get(id);
            if (!property.Status)
            {
                TempData["failed"]= property.Message;
                return RedirectToAction("List");
            }
            
            return View(property.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Rent")]
        public IActionResult RealRent( string id)
        {
            var response = _propertyService.RentProperty(id);

            if (response.Status)
            {
                
                return RedirectToAction("List");
            }
            return RedirectToAction("Rent", new{id = id});
            
        }


    }
}