using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilhaApiDesafio.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string EMail { get; set; }
        public string Telefone { get; set; }
    }
}