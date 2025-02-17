using CarFactory.DTOs;
using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;  

public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Agrega una nueva venta", Description = "Este endpoint agrega una nueva venta a la base de datos")]
    public IActionResult AddSale([FromBody] AddSaleDto saleDto)
    {
        if (saleDto == null)
        {
            return BadRequest("El cuerpo de la solicitud no puede estar vacio.");
        }

        if (string.IsNullOrEmpty(saleDto.DistributionCenterName))
        {
            return BadRequest("El centro de distribucion es obligatorio.");
        }

        if (!Enum.IsDefined(typeof(CarTypeEnum), saleDto.CarType))
        {
            return BadRequest("El tipo de coche no es valido.");
        }
        _saleService.InsertSale(saleDto);
        return CreatedAtAction(nameof(AddSale), new { saleDto }, saleDto);
    }

    [HttpGet("total-sales-volume")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el volumen total de ventas", Description = "Este endpoint devuelve el volumen total de ventas en la base de datos")]
    public IActionResult GetTotalSalesVolume()
    {
        var result = _saleService.GetTotalSalesVolume();
        return Ok(new { totalVolume = result });
    }

    [HttpGet("sales-by-center/{centerName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene las ventas de un centro de distribucion", Description = "Este endpoint devuelve todas las ventas de un centro de distribucion dado")]
    public IActionResult GetSalesByDistributionCenter(string centerName)
    {
        var result = _saleService.GetSalesByDistributionCenter(centerName);
        return Ok(result);
    }

    [HttpGet("sales-percentage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el porcentaje de ventas por modelo", Description = "Este endpoint devuelve el porcentaje de ventas para cada centro de ventas")]
    public IActionResult GetSalePercentageByModel()
    {
        var result = _saleService.GetSalesPercentageByModelPerCenter();

        return Ok(result);
    }
}
