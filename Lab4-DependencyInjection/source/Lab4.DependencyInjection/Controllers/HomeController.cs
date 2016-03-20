using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.DependencyInjection.Services;
using Microsoft.AspNet.Mvc;

namespace Lab4.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public IAggregateService AggregateService { get; set; }

        ISingletonService SingletonService { get; set; }
        ITransientService TransientService { get; set; }
        IScopedService ScopedService { get; set; }
        IInstanceService InstanceService { get; set; }

        public HomeController(IAggregateService aggregateService, ITransientService transientService, IScopedService scopedService, IInstanceService instanceService, ISingletonService singletonService)
        {
            AggregateService = aggregateService;
            TransientService = transientService;
            ScopedService = scopedService;
            SingletonService = singletonService;
            InstanceService = instanceService;
        }

        public IActionResult Index()
        {
            ViewBag.AggregateService = AggregateService;
            ViewBag.SingletonService = SingletonService;
            ViewBag.TransientService = TransientService;
            ViewBag.ScopedService = ScopedService;
            ViewBag.InstanceService = InstanceService;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
