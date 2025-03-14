using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using Repositories.Interface;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IContactInterface _contactRepo;
        public AdminController(IContactInterface contactRepo)
        {
            _contactRepo = contactRepo;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public async Task<ActionResult> List()
        {
            List<vm_Contact> contacts = await _contactRepo.GetAllWithUserName();
            return Json(contacts);
        }
    }
}