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
    public class UsuarioProdutosController : ControllerBase
    {
        private readonly ReCommerceContext _context;

        public UsuarioProdutosController(ReCommerceContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioProduto>>> GetUsuarioProduto()
        {
            return await _context.UsuarioProduto
                .Include(p => p.Produto)
                .Include(u => u.Usuario)
                .ToListAsync();
        }

        // GET: api/UsuarioProdutoes/5
        /*[HttpGet("{idUser}")]
        public async Task<ActionResult<List<Produto>>> GetProdutosByUser(int idUser)
        {
            var listaProdutos = new List<Produto>();

            listaProdutos = _context.UsuarioProduto
                                        .Where(usrProduto => usrProduto.UsuarioId == idUser)
                                       .Select(user => user.Produto).ToList();

            return listaProdutos;
        }*/
        

        // GET: api/UsuarioProdutoes/idUsuario
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<IEnumerable<UsuarioProduto>>> GetProdutosUsuario(int idUsuario)
        {
            return await _context.UsuarioProduto
                .Include(u => u.Produto)
                .Where(u => u.UsuarioId == idUsuario)
                .ToListAsync();
        }


        // PUT: api/UsuarioProdutos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioProduto(int id, UsuarioProduto usuarioProduto)
        {
            if (id != usuarioProduto.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioProdutoExists(id))
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

        // POST: api/UsuarioProdutos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsuarioProduto>> PostUsuarioProduto(UsuarioProduto usuarioProduto)
        {
            _context.UsuarioProduto.Add(usuarioProduto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioProdutoExists(usuarioProduto.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioProduto", new { id = usuarioProduto.UsuarioId }, usuarioProduto);
        }

        // DELETE: api/UsuarioProdutos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioProduto>> DeleteUsuarioProduto(int id)
        {
            var usuarioProduto = await _context.UsuarioProduto.FindAsync(id);
            if (usuarioProduto == null)
            {
                return NotFound();
            }

            _context.UsuarioProduto.Remove(usuarioProduto);
            await _context.SaveChangesAsync();

            return usuarioProduto;
        }

        private bool UsuarioProdutoExists(int id)
        {
            return _context.UsuarioProduto.Any(e => e.UsuarioId == id);
        }
    }
}
