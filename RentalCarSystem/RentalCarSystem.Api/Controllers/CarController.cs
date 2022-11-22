using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentalCarSystem.Api.Logger;
using RentalCarSystem.Core.Services;

namespace RentalCarSystem.Api.Controllers
{
    public class CarController : BaseController
    {
        private readonly ILog _log;
        private readonly CarService _carService;
        public CarController(CarService carService)
        {
            _log = Log.GetInstance;
            _carService = carService;
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    _log.LogExceptions(filterContext.Exception.ToString());
        //    filterContext.ExceptionHandled = true;
        //    this.View("Error").ExecuteResult(this.ControllerContext);
        //}
    }
}
