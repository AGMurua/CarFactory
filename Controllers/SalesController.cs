using CarFactory.DTOs;
using CarFactory.Services.Interfaces;
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
        public IActionResult AddSale([FromBody] SaleDto saleDto)
        {
            var stopwatch = Stopwatch.StartNew();

            _saleService.InsertSale(saleDto);

            stopwatch.Stop();
            var test = stopwatch.ElapsedMilliseconds;
            return Ok();
        }

        [HttpGet("total-sales-volume")]
        public IActionResult GetTotalSalesVolume()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = _saleService.GetTotalSalesVolume();

            stopwatch.Stop();

            return Ok(result);
        }

    }
}
