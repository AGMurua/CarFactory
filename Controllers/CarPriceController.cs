using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarFactory.Controllers
{
    public class CarPriceController : Controller
    {
        private readonly ICarService _carTypeService;

        public CarPriceController(ICarService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        /// <summary>
        /// Obtiene todos los tipos de vehiculos con sus precios
        /// </summary>
        /// <returns>Obtiene todos los tipos de vehiculos con sus precios y impuestos si aplica </returns>
        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll() => Ok(_carTypeService.GetAllCarPrice());
    }
}
