using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReCommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Senha { get; set; }
        public List<UsuarioEndereco> UsuarioEnderecos { get; set; }
        public virtual List<Troca> Trocas { get; set; }
        public List<UsuarioProduto> UsuarioProdutos { get; set; }
    }
}
