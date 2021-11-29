using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReCommerce.Models
{
    public class Troca
    {
        public int Id { get; set; }
        public virtual Produto ProdutosUsuarioUm { get; set; }
        public virtual Produto ProdutosUsuarioDois { get; set; }
        public int ProdutosUsuarioUmId { get; set; }
        public int ProdutosUsuarioDoisId { get; set; }
        public DateTime dia { get; set; }
        public bool status { get; set; }
        public virtual Usuario UsuarioUm { get; set; }
        public int UsuarioUmId { get; set; }

        public virtual Usuario UsuarioDois { get; set; }
        public int UsuarioDoisId { get; set; }
    }
}
