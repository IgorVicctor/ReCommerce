using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCommerce.Models
{
    public class UsuarioProduto
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public Usuario Usuario { get; set; }
        public virtual Produto Produto { get; set; }
    }
}