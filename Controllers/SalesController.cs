using CarFactory.DTOs;
using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Controlador para gestionar las ventas de autos
/// </summary>
[ApiController]
[Route("api/sales")]
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
    /// <param name="saleDto">Datos de la venta</param>
    /// <returns>Resultado de la operacion</returns>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Agrega una nueva venta", Description = "Este endpoint agrega una nueva venta a la base de datos")]
    public IActionResult AddSale([FromBody] AddSaleDto saleDto)
    {
        try
        {
            _saleService.InsertSale(saleDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Comuniquese con soporte");
        }
        return CreatedAtAction(nameof(AddSale), new { saleDto }, saleDto);
    }

    /// <summary>
    /// Obtiene el volumen total de ventas
    /// </summary>
    /// <returns>Volumen total de ventas</returns>
    [HttpGet("total-sales-volume")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el volumen total de ventas", Description = "Este endpoint devuelve el volumen total de ventas en la base de datos")]
    public IActionResult GetTotalSalesVolume()
    {
        var result = _saleService.GetTotalSalesVolume();
        return Ok(new { totalVolume = result });
    }

    /// <summary>
    /// Obtiene el volumen de ventas por centro de distribucion
    /// </summary>
    /// <param name="centerName">Nombre del centro de distribucion (opcional)</param>
    /// <returns>Ventas agrupadas por centro de distribucion</returns>
    [HttpGet("sales-by-center")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el volumen para un centro de distribucion", Description = "Este endpoint devuelve todas las ventas de un centro de distribucion dado o todos si no se asigna valor a centerName")]
    public IActionResult GetSalesByDistributionCenter([FromQuery] string centerName = null)
    {
        var result = _saleService.GetSalesByDistributionCenter(centerName);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene el porcentaje de ventas por modelo en cada centro
    /// </summary>
    /// <returns>Porcentaje de ventas agrupado por centro y modelo</returns>
    [HttpGet("sales-percentage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Obtiene el porcentaje de ventas por modelo", Description = "Este endpoint devuelve el porcentaje de ventas para cada centro de ventas")]
    public IActionResult GetSalePercentageByModel()
    {
        var result = _saleService.GetSalesPercentageByModelPerCenter();
        return Ok(result);
    }
}
