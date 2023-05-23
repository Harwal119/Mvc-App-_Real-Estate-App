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
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
    
        [Authorize]   
        [HttpGet]
        public IActionResult List()
        {
            var roles = _roleService.GetAll();
            return View(roles.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
         [HttpPost]
        public IActionResult Add(CreateRoleRequestModel model)
        {
            var role = _roleService.Create(model);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var role = _roleService.Get(id);
            return View(role.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var role = _roleService.Get(id);
            var updateRole = new UpdateRoleRequestModel()
            {
                Name = role.Data.Name,
                Description = role.Data.Description
            };
            return View(updateRole);
        
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdateRoleRequestModel model)
        {
            _roleService.Update(id,model);
            return RedirectToAction("List");
        }

        // [HttpGet]
        // public IActionResult Delete(string id)
        // {
        //     var role = _roleService.Get(id);
        //     return View(role.Data);
        // }

        // [HttpPost, ActionName("Delete")]
        // public IActionResult softDelete(string id)
        // {
        //     return View("List");
        // }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var role = _roleService.Get(id);
            return View(role.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
           _roleService.Delete(id);
            return RedirectToAction("List");
        }

        
        
    }
}