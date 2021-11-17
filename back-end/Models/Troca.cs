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
        public  List<Produto> ProdutosUsuarioUm { get; set; }
        public  List<Produto> ProdutosUsuarioDois { get; set; }

        //public int ProdutoId { get; set; }
        public DateTime dia { get; set; }
        public bool status { get; set; }
        public virtual Usuario UsuarioUm { get; set; }
        public int UsuarioUmId { get; set; }

        public virtual Usuario UsuarioDois { get; set; }
        public int UsuarioDoisId { get; set; }
    }
}
