using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReCommerce.Dados;
using ReCommerce.Models;

namespace ReCommerce.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ReCommerceContext _context;

        public UsuariosController(ReCommerceContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario
                .Include(up => up.UsuarioProdutos)
                .Include(ue => ue.UsuarioEnderecos)
                //.Include(up => up.UsuarioProdutos.Select(p=> p.Produto))
                .Include(tr => tr.Trocas)
                .ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            _context.Entry(usuario).Collection(tarefa => tarefa.UsuarioProdutos).Load();
            //_context.Entry(usuario).Collection(tarefa => tarefa.Produtos).Load();

            if (usuario == null)
            {
                return NotFound();
            }


            return usuario;
        }
        // PUT: api/Usuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }

        [HttpGet("autentica")]
        
        public async Task<ActionResult<Usuario>> AuthUsuario(string email, string senha)
        {
            var usuario = _context.Usuario
                .Where(usr => usr.Email == email && usr.Senha == senha)
                .FirstOrDefault();

           
            if (usuario == null)
            {
                return NotFound();
            }


            return usuario;
        }



    }
}
