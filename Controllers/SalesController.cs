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

    /// <summary>
    /// Agrega una nueva venta
    /// </summary>
    /// <remarks>
    /// Este endpoint agrega una nueva venta a la base de datos (mockeada)
    /// </remarks>
    /// <param name="saleDto">Los detalles de la venta a agregar</param>
    /// <returns>La venta recien creada</returns>
    /// <response code="201">Venta creada correctamente.</response>
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

    /// <summary>
    /// Obtiene el volumen total de ventas
    /// </summary>
    /// <remarks>
    /// Este endpoint devuelve el volumen total de ventas en la base de datos (mockeada)
    /// </remarks>
    /// <returns>El volumen total de ventas.</returns>
    /// <response code="200">Volumen total de ventas.</response>
    [HttpGet("total-sales-volume")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el volumen total de ventas", Description = "Este endpoint devuelve el volumen total de ventas en la base de datos")]
    public IActionResult GetTotalSalesVolume()
    {
        var result = _saleService.GetTotalSalesVolume();
        return Ok(new { totalVolume = result });
    }

    /// <summary>
    /// Obtiene las ventas de un centro de distribucion
    /// </summary>
    /// <remarks>
    /// Este endpoint devuelve todas las ventas de un centro de distribucion dado
    /// </remarks>
    /// <param name="centerName">El nombre del centro de distribucion</param>
    /// <returns>Las ventas asociadas al centro de distribucion</returns>
    /// <response code="200">Ventas del centro de distribucion</response>
    [HttpGet("sales-by-center/{centerName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene las ventas de un centro de distribucion", Description = "Este endpoint devuelve todas las ventas de un centro de distribucion dado")]
    public IActionResult GetSalesByDistributionCenter(string centerName)
    {
        var result = _saleService.GetSalesByDistributionCenter(centerName);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene el porcentaje de ventas de un modelo por centro
    /// </summary>
    /// <remarks>
    /// Este endpoint devuelve el porcentaje de ventas para un tipo de coche y centro de distribucion
    /// </remarks>
    /// <param name="carType">El tipo de coche (CarTypeEnum)</param>
    /// <param name="center">El nombre del centro de distribucion</param>
    /// <returns>El porcentaje de ventas</returns>
    /// <response code="200">Porcentaje de ventas por model</response>
    [HttpGet("sales-percentage/{carType}/{center}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el porcentaje de ventas por modelo", Description = "Este endpoint devuelve el porcentaje de ventas para un tipo de coche y centro de distribucion")]
    public IActionResult GetSalePercentageByModel(CarTypeEnum carType, string center)
    {
        var result = _saleService.GetSalePercentageByModel(carType, center);

        return Ok(result);
    }
}
