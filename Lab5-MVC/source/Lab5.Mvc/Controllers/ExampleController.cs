using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lab5.Mvc.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Lab5.Mvc.Controllers
{
    [Authorize()]
    public class ExampleController: Controller
    {
        public ApplicationDbContext Context { get; set; }

        public ExampleController(ApplicationDbContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var user = Context.Users.First(x => x.Id == User.GetUserId());

            ViewData.Model = user;

            return View();
        }

        public IActionResult Two(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult Index2()
        {
            return View("Two");
        }
    }
}
