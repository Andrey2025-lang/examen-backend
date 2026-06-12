using HackerRank1.Entities;
using HackerRank1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerRank1.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Ruta api/fraud
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        // Inyeccion de servicio
        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        //GET para consultar todos los reportes (Retorna 200 OK)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fraud>>> GetFrauds()
        {
            try
            {
                var frauds = await _fraudService.GetAllFraudsAsync();
                return Ok(frauds); // Respuesta HTTP 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //POST para insertar reportes 
        [HttpPost]
        public async Task<ActionResult<Fraud>> CreateFraud([FromBody] Fraud fraud)
        {
            // Validar si es correcto (Retorna 400 Bad Request si faltan datos)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newFraud = await _fraudService.CreateFraudAsync(fraud);

                // Retorna 201 Created indicando éxito al crear el recurso
                return CreatedAtAction(nameof(GetFrauds), new { id = newFraud.Id }, newFraud);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar el reporte: {ex.Message}");
            }
        }
    }
}