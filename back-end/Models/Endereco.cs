using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCommerce.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Residencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
        public List<UsuarioEndereco> UsuarioEnderecos { get; set; }
    }
}
