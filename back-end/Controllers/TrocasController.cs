using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReCommerce.Dados;
using ReCommerce.Models;

namespace ReCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrocasController : ControllerBase
    {
        private readonly ReCommerceContext _context;

        public TrocasController(ReCommerceContext context)
        {
            _context = context;
        }

        
        // GET: api/Trocas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Troca>>> GetTroca()
        {
            return await _context.Troca
                .Include(p => p.ProdutosUsuarioUm)
                .Include(p => p.ProdutosUsuarioDois)
                .Include(u => u.UsuarioUm)
                .Include(u => u.UsuarioDois)
                .ToListAsync();
        }

        // GET: api/Trocas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Troca>> GetTroca(int id)
        {
            var troca = await _context.Troca.FindAsync(id);

            if (troca == null)
            {
                return NotFound();
            }

            return troca;
        }        

        // PUT: api/Trocas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTroca(int id, Troca troca)
        {
            if (id != troca.Id)
            {
                return BadRequest();
            }

            _context.Entry(troca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrocaExists(id))
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

        // POST: api/Trocas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Troca>> PostTroca(Troca troca)
        {
            _context.Troca.Add(troca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTroca", new { id = troca.Id }, troca);
        }

        // DELETE: api/Trocas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Troca>> DeleteTroca(int id)
        {
            var troca = await _context.Troca.FindAsync(id);
            if (troca == null)
            {
                return NotFound();
            }

            _context.Troca.Remove(troca);
            await _context.SaveChangesAsync();

            return troca;
        }

        private bool TrocaExists(int id)
        {
            return _context.Troca.Any(e => e.Id == id);
        }
    }
}
