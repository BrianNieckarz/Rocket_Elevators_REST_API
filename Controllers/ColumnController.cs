#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorREST.Models;

namespace RocketElevatorREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly feliciaHartonoContext _context;

        public ColumnController(feliciaHartonoContext context)
        {
            _context = context;
        }

        // GET: api/Column
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        }

        // GET: api/Column/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(long id)
        {
            var column = await _context.Columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // PUT: api/Column/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn(long id, Column column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
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

        // POST: api/Column
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Column>> PostColumn(Column column)
        {
            _context.Columns.Add(column);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumn", new { id = column.Id }, column);
        }

        // DELETE: api/Column/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColumn(long id)
        {
            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColumnExists(long id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }
    }
}