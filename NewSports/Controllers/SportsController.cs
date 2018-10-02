using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewSports.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewSports.Controllers
{
    [Produces("application/json")]
    [Route("api/Sports")]
    public class SportsController : Controller
    {
        private readonly YellowTailDBContext _context;

        public SportsController(YellowTailDBContext context)
        {
            _context = context;
        }

        // GET: api/SportsTbs
        [HttpGet]
        public IActionResult GetAllSportsTb()
        {
            return Ok(_context.SportsTb);
        }

        // GET: api/SportsTbs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSportsTb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportsTb = await _context.SportsTb.SingleOrDefaultAsync(m => m.SportsId == id);

            if (sportsTb == null)
            {
                return NotFound();
            }

            return Ok(sportsTb);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        public async Task<IActionResult> PostSportsTb([FromBody] SportsTb sportsTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SportsTb.Add(sportsTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SportsTbExists(sportsTb.SportsId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSportsTb", new { id = sportsTb.SportsId }, sportsTb);
        }

        // PUT: api/SportsTbs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportsTb([FromRoute] int id, [FromBody] SportsTb sportsTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sportsTb.SportsId)
            {
                return BadRequest();
            }

            _context.Entry(sportsTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportsTbExists(id))
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

        // DELETE: api/SportsTbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportsTb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportsTb = await _context.SportsTb.SingleOrDefaultAsync(m => m.SportsId == id);
            if (sportsTb == null)
            {
                return NotFound();
            }

            _context.SportsTb.Remove(sportsTb);
            await _context.SaveChangesAsync();

            return Ok(sportsTb);
        }

        private bool SportsTbExists(int id)
        {
            return _context.SportsTb.Any(e => e.SportsId == id);
        }
    }
}
