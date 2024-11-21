using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VinotecaRecu.Data.Entities;
using VinotecaRecu.Models;
using VinotecaRecu.Services.Interfaces;

namespace VinotecaRecu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WineController : ControllerBase
    {

        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult GetAllWine()
        {
            var wines = _wineService.GetAllWine();
            return Ok(wines);
        }

        [HttpPost]
        public IActionResult CreateWine([FromBody] CreateWineDTO dto)
        {
            _wineService.CreateWine(dto);
            return Ok(dto);
        }

        [HttpGet("variety/{variety}")]
        public IActionResult GetStockByVariety(string variety)
        {
            var stock = _wineService.GetStockByVariety(variety);

            if (stock == null || stock.Count == 0)
                return NotFound($"No se encontro stock para la variedad seleccionada: {variety}");

            return Ok(stock);
        }

        [HttpPut("{wineId}/stock")]
        public IActionResult UpdateWineStock(int wineId, [FromBody] UpdateWineStockDTO dto)
        {
            try
            {
                _wineService.UpdateWineStock(wineId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}