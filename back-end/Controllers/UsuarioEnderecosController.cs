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
    public class UsuarioEnderecosController : ControllerBase
    {
        private readonly ReCommerceContext _context;

        public UsuarioEnderecosController(ReCommerceContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioEnderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEndereco>>> GetUsuarioEndereco()
        {
            return await _context.UsuarioEndereco
                .Include(u => u.Usuario)
                .Include(e => e.Endereco)
                .ToListAsync();
        }

        // GET: api/UsuarioEnderecos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEndereco>> GetUsuarioEndereco(int id)
        {
            var usuarioEndereco = await _context.UsuarioEndereco.FindAsync(id);

            if (usuarioEndereco == null)
            {
                return NotFound();
            }

            return usuarioEndereco;
        }

        // PUT: api/UsuarioEnderecos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioEndereco(int id, UsuarioEndereco usuarioEndereco)
        {
            if (id != usuarioEndereco.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioEndereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEnderecoExists(id))
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

        // POST: api/UsuarioEnderecos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsuarioEndereco>> PostUsuarioEndereco(UsuarioEndereco usuarioEndereco)
        {
            _context.UsuarioEndereco.Add(usuarioEndereco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioEnderecoExists(usuarioEndereco.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioEndereco", new { id = usuarioEndereco.UsuarioId }, usuarioEndereco);
        }

        // DELETE: api/UsuarioEnderecos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioEndereco>> DeleteUsuarioEndereco(int id)
        {
            var usuarioEndereco = await _context.UsuarioEndereco.FindAsync(id);
            if (usuarioEndereco == null)
            {
                return NotFound();
            }

            _context.UsuarioEndereco.Remove(usuarioEndereco);
            await _context.SaveChangesAsync();

            return usuarioEndereco;
        }

        private bool UsuarioEnderecoExists(int id)
        {
            return _context.UsuarioEndereco.Any(e => e.UsuarioId == id);
        }
    }
}
