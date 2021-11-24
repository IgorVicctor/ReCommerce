using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCommerce.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public string marca { get; set; }
        public double tempoDeUso { get; set; }
        public int qtdEstoque { get; set; }
        //public byte[] Imagem { get; set; }
        public List<UsuarioProduto> UsuarioProduto { get; set; }
        public virtual List<Troca> Trocas { get; set; }
    }
}
