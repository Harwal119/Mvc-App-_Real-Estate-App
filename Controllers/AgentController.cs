using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateMvcApp.Models.Dtos;
using RealEstateMvcApp.Models.Entities;
using RealEstateMvcApp.Models.Service.Interfaces;

namespace RealEstateMvcApp.Controllers
{
    // [Route("[controller]")]
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CreateAgentRequestModel model)
        {
           var agent = _agentService.Create(model);
           if (agent is not null)
           {
                TempData["success"] = "Created Successfully";
           }
            return RedirectToAction("List");
        }

        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
           var principal = _agentService.GetAll();
            return View(principal.Data);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var client = _agentService.Get(id);
            var updateRole = new UpdateAgentRequestModel()
            {
                Name = client.Data.Name,
                PhoneNumber = client.Data.PhoneNumber,
                Address = client.Data.Address,

            };
            return View(updateRole);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id, UpdateAgentRequestModel model)
        {
            _agentService.Update(id,model);
            return RedirectToAction("List");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var client = _agentService.Get(id);
            return View(client.Data);
        }

        // [HttpGet]
        // public IActionResult Delete(string id)
        // {
        //     var manager = _agentService.Get(id);
        //     return View(manager.Data);
        // }
        // [HttpPost, ActionName("Delete")]
        // public IActionResult softDelete(string id)
        // {
        //     return View();
        // }

        //  [HttpGet]
        // public IActionResult Delete(string id)
        // {
        //     if(HttpContext.Session.Get(id) is not null)
        //     {
        //         var agent = _agentService.Get(id);
        //         return View(agent);
        //     }
        //     return RedirectToAction("Login" , "User");
            
        // }
        // [HttpPost, ActionName("Delete")]
        // public IActionResult RealDelete(int id)
        // {
        //     /*if(HttpContext.Session.GetString("email") is not null)
        //     {
        //         _pieService.DeletePie(id);
        //         return RedirectToAction("Pies");

        //     }*/
           
        //     return RedirectToAction("Login" , "User");
        // }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var agent = _agentService.Get(id);
            return View(agent.Data);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
           _agentService.Delete(id);
            return RedirectToAction("List");
        }

        
    }
}