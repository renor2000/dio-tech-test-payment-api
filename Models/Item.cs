using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilhaApiDesafio.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; } 
        public int Qtd { get; set; }
        public float Valor { get; set; }

        public virtual Venda Venda {get; set;}

        public virtual Produto Produto {get; set;}



        
    }
}