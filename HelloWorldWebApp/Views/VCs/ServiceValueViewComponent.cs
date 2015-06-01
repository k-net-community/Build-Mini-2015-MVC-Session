using Microsoft.AspNet.Mvc;
using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebApp.Views.VCs
{
    [ViewComponent(Name = "ServiceValueVC")]
    public class ServiceValueViewComponent : ViewComponent
    {
        private IServiceComponent _serviceComponent = null;

        public ServiceValueViewComponent(IServiceComponent ServiceComponent)
        {
            this._serviceComponent = ServiceComponent;
        }

        public IViewComponentResult Invoke()
        {
            return Content(this._serviceComponent.GetValue().ToString());
        }
        
        public IViewComponentResult Invoke(int Value)
        {
            return Content((this._serviceComponent.GetValue() * Value).ToString());
        }        
    }
}
