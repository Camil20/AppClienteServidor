using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetallesController : ControllerBase
    {
        private readonly AppClienteServidorContext _context;

        public FacturaDetallesController(AppClienteServidorContext context)
        {
            _context = context;
        }

        // GET: api/FacturaDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDetalle>>> GetFacturaDetalles()
        {
            return await _context.FacturaDetalles.ToListAsync();
        }

        // GET: api/FacturaDetalles/
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDetalle>> GetFacturaDetalle(int id)
        {
            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);

            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return facturaDetalle;
        }

        // PUT: api/FacturaDetalles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaDetalle(int id, FacturaDetalle facturaDetalle)
        {
            if (id != facturaDetalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(facturaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaDetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FacturaDetalles
        [HttpPost]
        public async Task<ActionResult<FacturaDetalle>> PostFacturaDetalle(FacturaDetalle facturaDetalle)
        {
            _context.FacturaDetalles.Add(facturaDetalle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturaDetalleExists(facturaDetalle.DetalleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacturaDetalle", new { id = facturaDetalle.DetalleId }, facturaDetalle);
        }

        // DELETE: api/FacturaDetalles/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaDetalle(int id)
        {
            var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            _context.FacturaDetalles.Remove(facturaDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaDetalleExists(int id)
        {
            return _context.FacturaDetalles.Any(e => e.DetalleId == id);
        }
    }
}
