using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarFactory.Controllers
{
    public class CarTypeController : Controller
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet("price/{carType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Obtiene el precio de un tipo de uato", Description = "Este endpoint devuelve el precio de un tipo de uato")]
        public IActionResult GetSalePercentageByModel(CarTypeEnum carType)
        {
            var result = _carTypeService.GetPrice(carType);

            return Ok(result);
        }
    }
}
