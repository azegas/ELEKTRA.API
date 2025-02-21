using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELEKTRA.API.Models;

namespace ELEKTRA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculationContext _context;

        public CalculationsController(CalculationContext context)
        {
            _context = context;
        }

        // GET: api/Calculations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculation>>> GetCalculations()
        {
            return await _context.Calculations.ToListAsync();
        }

        // GET: api/Calculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> GetCalculation(int id)
        {
            var calculation = await _context.Calculations.FindAsync(id);

            if (calculation == null)
            {
                return NotFound();
            }

            return calculation;
        }

        // PUT: api/Calculations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculation(int id, Calculation calculation)
        {
            if (id != calculation.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculationExists(id))
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

        // POST: api/Calculations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calculation>> PostCalculation(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculation", new { id = calculation.Id }, calculation);
        }

        // DELETE: api/Calculations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculation(int id)
        {
            var calculation = await _context.Calculations.FindAsync(id);
            if (calculation == null)
            {
                return NotFound();
            }

            _context.Calculations.Remove(calculation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculationExists(int id)
        {
            return _context.Calculations.Any(e => e.Id == id);
        }
    }
}
