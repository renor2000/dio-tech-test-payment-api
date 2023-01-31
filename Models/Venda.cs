using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilhaApiDesafio.Models
{
    public class Venda
    {
        public int               VendaId { get; set; }
        public DateTime          Data { get; set; }
        public int               VendedorId { get; set; }
        public EnumStatusVenda   Status { get; set; }
        public ICollection<Item> Items {get; set;}

        public virtual Vendedor  Vendedor {get; set;}

    }
}