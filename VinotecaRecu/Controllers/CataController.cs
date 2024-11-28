using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinotecaRecu.Data;
using VinotecaRecu.Models;
using VinotecaRecu.Services;
using VinotecaRecu.Services.Interfaces;

namespace VinotecaRecu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataController : ControllerBase
    {
        private readonly CataService _cataService;
        private readonly VinotecaRecuContext _context;

        public CataController(CataService cataService, VinotecaRecuContext context)
        {
            _cataService = cataService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCata()
        {
            var catas = _cataService.GetAllCata();
            return Ok(catas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCata([FromBody] CreateCataDTO dto)
        {
            try
            {
                await _cataService.CreateCata(dto);
                return Ok(); // Retorna un código 200 si todo está bien
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna un BadRequest con el mensaje de la excepción
            }
        }



        [HttpPut("{id}/invitados")]
        public IActionResult UpdateInvitados(int id, [FromBody] UpdateInvitadosDTO dto)
        {
            try
            {
                _cataService.UpdateInvitados(id, dto.Invitados);
                return Ok("Lista de invitados actualizada correctamente.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("upcoming")]
        public IActionResult GetUpcomingCatas()
        {
            var upcomingCatas = _context.Catas
                .Where(c => c.Fecha > DateTime.Now)
                .Select(c => new CataDTO
                {
                    Id = c.Id,
                    Nombre = c.Name,
                    Fecha = c.Fecha,
                    Wines = c.Wines.Select(w => new WineDTO
                    {
                        Id = w.Id,
                        Nombre = w.Name,
                        Variedad = w.Variety
                    }).ToList()
                })
                .ToList();

            return Ok(upcomingCatas);
        }

    }
}
