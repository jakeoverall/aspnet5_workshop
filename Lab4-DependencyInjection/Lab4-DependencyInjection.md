# Lab 4 Dependency Injection
Backed in from the ground up.  You can use another container but we'll just use the backed in one.

(From docs.asp.net)

ASP.NET services can be configured with the following lifetimes:

* Transient
    Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.
* Scoped
    Scoped lifetime services are created once per request.
* Singleton
    Singleton lifetime services are created the first time they are requested, and then every subsequent request will use the same instance. If your application requires singleton behavior, allowing the services container to manage the service’s lifetime is recommended instead of implementing the singleton design pattern and managing your object’s lifetime in the class yourself.
* Instance
    You can choose to add an instance directly to the services container. If you do so, this instance will be used for all subsequent requests (this technique will create a Singleton-scoped instance). One key difference between Instance services and Singleton services is that the Instance service is created in ConfigureServices, while the Singleton service is lazy-loaded the first time it is requested.
    
 
## Configuration

Given the following interface and implemenation classes

````
    public interface ISingletonService
    {
        string Message { get; }
    }

    public interface ITransientService
    {
        string Message { get; }
    }

    public interface IScopedService
    {
        string Message { get; }
    }

    public interface IInstanceService
    {
        string Message { get; }
    }

    public interface IAggregateService
    {
        IInstanceService Instance { get; }
        IScopedService Scoped { get; }
        ITransientService Transient { get; }
        ISingletonService Singleton { get; }
    }
    
    public class InstanceService : IInstanceService
    {
        public string Message { get; set; }
    }
    
    public class ScopedService: IScopedService
    {
        public string Message { get; }

        public ScopedService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
    
    public class SingletonService: ISingletonService
    {
        public String Message { get; }

        public SingletonService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
    
    public class TransientService: ITransientService
    {
        public string Message { get; }

        public TransientService()
        {
            Message = Guid.NewGuid().ToString();
        }
    }
    
    public class AggregateService : IAggregateService
    {
        public AggregateService(IInstanceService instance, IScopedService scoped, ITransientService transient,ISingletonService singleton)
        {
            Instance = instance;
            Scoped = scoped;
            Transient = transient;
            Singleton = singleton;
        }

        public IInstanceService Instance { get; }
        public IScopedService Scoped { get; }
        public ITransientService Transient { get; }
        public ISingletonService Singleton { get; }
    }

````


## Update the HomeController and ~/Views/Home/index.cshtml

````
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
 }

````

index.cshtml
````
@{
    ViewData["Title"] = "Home Page";
}
<h1>Scopes</h1>

<div>Singleton: @ViewBag.SingletonService.Message </div>
<div>InstanceService: @ViewBag.InstanceService.Message </div>
<div>TransientService: @ViewBag.TransientService.Message </div>
<div>ScopedService: @ViewBag.ScopedService.Message </div>

<h1>From Aggregate Service</h1>

<div>Singleton: @ViewBag.AggregateService.Singleton.Message </div>
<div>InstanceService: @ViewBag.AggregateService.Instance.Message </div>
<div>TransientService: @ViewBag.AggregateService.Transient.Message <span style="color: red">different!</span></div>
<div>ScopedService: @ViewBag.AggregateService.Scoped.Message <span style="color: green">same as above!</span></div>
````