using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using MyService;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger = null;
        private IServiceComponent _serviceComponent = null;

        public HomeController(ILoggerFactory factory, IServiceComponent component)
        {
            this._logger = factory.CreateLogger("HomeController");
            this._serviceComponent = component;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            this._logger.LogWarning("Test");
            return Content("Hello ASP.NET MVC 6");
        }

        public IActionResult Customers()
        {
            using (var db = new NorthwindDataContext())
            {
                return View(db.Customers.ToList());
            }
        }

        public IActionResult ServiceValue()
        {
            return View();
            //return Content(this._serviceComponent.GetValue().ToString("###,###,##0"));
        }

        public IActionResult ServiceValue2()
        {
            return View();
            //return Content(this._serviceComponent.GetValue().ToString("###,###,##0"));
        }
    }
}
