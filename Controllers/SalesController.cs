using CarFactory.DTOs;
using CarFactory.Helper.Types;
using CarFactory.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarFactory.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("add")]
        public IActionResult AddSale([FromBody] AddSaleDto saleDto)
        {
            _saleService.InsertSale(saleDto);
            return CreatedAtAction(nameof(AddSale), new { saleDto }, saleDto);
        }

        [HttpGet("total-sales-volume")]
        public IActionResult GetTotalSalesVolume()
        {
            var result = _saleService.GetTotalSalesVolume();
            return Ok(new { totalVolume = result });
        }

        [HttpGet("sales-by-center/{centerName}")]
        public IActionResult GetSalesByDistributionCenter(string centerName)
        {
            var result = _saleService.GetSalesByDistributionCenter(centerName);
            return Ok(result);
        }

        [HttpGet("sales-percentage/{carType}/{center}")]
        public IActionResult GetSalePercentageByModel(CarTypeEnum carType, string center)
        {
            var result = _saleService.GetSalePercentageByModel(carType, center);

            return Ok(result);
        }
    }
}
