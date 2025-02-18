using CarFactory.DTOs;
using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Controlador para gestionar las ventas de autos
/// </summary>
[ApiController]
[Route("api/center")]
public class CenterController : ControllerBase
{
    private readonly ICenterService _centerService;

    public CenterController(ICenterService centerService)
    {
        _centerService = centerService;
    }

    /// <summary>
    /// Obtiene todos los centros
    /// </summary>
    /// <returns>Todos los centros de ventas</returns>
    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSalesByDistributionCenter() => Ok(_centerService.GetAllCenters());

    /// <summary>
    /// Obtiene el centro por id
    /// </summary>
    /// <returns>Un centro solicitado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCenterById(int id)
    {
        var center = _centerService.GetCenterById(id);
        return center != null ? Ok(center) : NotFound();
    }
}
