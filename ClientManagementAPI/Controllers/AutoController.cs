using ClientManagementAPI.Data;
using ClientManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoController(ApplicationDbContext context)
        {
            _context = context;
        }
        /////

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autos = await _context.Autos.ToListAsync();
            return Ok(autos);
        }


        //
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("no id");
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }

            return Ok(await _context.Autos.FindAsync(id));
        }
        //
        [HttpPost]
        public async Task<IActionResult> Create(Auto auto)
        {
            auto.RegistrationDate = DateTime.UtcNow;

            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = auto.Id }, auto);
        }
        //
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, Auto auto)
        {
            if(id != auto.Id)
            {
                return BadRequest();
            }
            var existingAuto = await _context.Autos.FindAsync(id);

            if (existingAuto == null)
            {
                return NotFound();
            }

            existingAuto.FullName = auto.FullName;
            existingAuto.Marka = auto.Marka;
            existingAuto.Color = auto.Color;
            existingAuto.GOSNubmer = auto.GOSNubmer;

            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var autos = await _context.Autos.FindAsync(id);
            if(autos == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(autos);
            return NoContent();
        }
    }
}
