using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Entities.DTOs;

namespace Gudumholm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HouseholdsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Households
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Household>>> GetHouseholds()
        {
            return await _context.Households.ToListAsync();
        }

        // GET: api/Households/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Household>> GetHousehold(int id)
        {
            var household = await _context.Households.FindAsync(id);

            if (household == null)
            {
                return NotFound();
            }

            return household;
        }

        // PUT: api/Households/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHousehold(int id, Household household)
        {
            if (id != household.Id)
            {
                return BadRequest();
            }

            _context.Entry(household).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseholdExists(id))
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

        // POST: api/Households
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Household>> PostHousehold(Household household)
        {
            _context.Households.Add(household);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHousehold", new { id = household.Id }, household);
        }

        // DELETE: api/Households/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHousehold(int id)
        {
            var household = await _context.Households.FindAsync(id);
            if (household == null)
            {
                return NotFound();
            }

            _context.Households.Remove(household);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HouseholdExists(int id)
        {
            return _context.Households.Any(e => e.Id == id);
        }
    }
}
