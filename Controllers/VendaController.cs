using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendasContext _context;

        public VendaController(VendasContext context)
        {
            _context = context;
        }


        
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int idVenda)
        {
            var venda = _context.Vendas.Find(idVenda);

            if (venda == null)
                return BadRequest(new { Erro = "Ainda não existe venda com essa numeração" });  //return NotFound();
            return Ok(venda);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            // DONE: Buscar todas as vendas no banco utilizando o EF
            var venda = _context.Vendas;
            return Ok(venda);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var vendaQtd = _context.Vendas.Count(x => x.Data.Date == data.Date);
            if (vendaQtd == 0)
               return BadRequest(new { Erro = "Não existe Venda para a data "+data.Day+"/"+data.Month+"/"+data.Year });

            var venda = _context.Vendas.Where(x => x.Data.Date == data.Date);
            return Ok(venda);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusVenda status)
        {
            // DONE: Buscar  as vendas no banco utilizando o EF, que contenha o status recebido por parâmetro
            var venda = _context.Vendas.Where(x => x.Status == status); 
            return Ok(venda);
        }



        [HttpPut("{id}")]
        public IActionResult Atualizar(int idVenda, Venda venda, int novoStatus)
        {
            var vendaBanco = _context.Vendas.Find(idVenda);

            if (vendaBanco == null)
                return BadRequest(new { Erro = "Não existe esta Venda na Base de Dados" }); //return NotFound();

            var oldStatus = vendaBanco.Status;
            if (oldStatus==EnumStatusVenda.AguardandoPagamento & novoStatus!=2 & novoStatus!=5)
                throw new Exception("Mudança de Status não permitida");
            if (oldStatus==EnumStatusVenda.PagamentoAprovado & novoStatus!=3 & novoStatus!=5)
                throw new Exception("Mudança de Status não permitida");
            if (oldStatus==EnumStatusVenda.EnviadoParaATransportadora & novoStatus!=4)
                throw new Exception("Mudança de Status não permitida");

            vendaBanco.Status = (EnumStatusVenda)novoStatus;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(vendaBanco);
        }


        [HttpPost]
        public IActionResult Criar(Venda venda)
        {

            if (venda.VendedorId == 0)
              return BadRequest(new { Erro = "O Vendedor Precisa ser Informado" });

            if (venda.Data == DateTime.MinValue)
              return BadRequest(new { Erro = "A data da venda não pode ser vazia" });

            /*if (venda.VendedorId==1)
               throw new Exception("O nome do Vendedor é " + venda.VendedorId);*/

            if (venda.Items.Count==0)
               throw new Exception("A Venda Precisa ter pelo menos 1 item");





            // DONE: Adicionar a venda recebida no EF e salvar as mudanças (save changes)
            //O Status será Aguardando Pagamento  
            //venda.Status ++; //= venda.Status + 1; 
            
            //_context.Add(venda);

            //_context.Add(vendedor);
            _context.Add(venda);

            
            
            //_context.Add(item);
            _context.SaveChanges();
            return BadRequest(new { Erro = "Recebi " + venda.Items });
            //return Ok(); //CreatedAtAction(nameof(ObterPorId), new { idVenda = venda.VendaId }, venda);
        }     



        
/*
        [HttpPost]
        public IActionResult Criar()
        {
            HttpClient client = new HttpClient();
            Uri baseAdress = new Uri("http://localhost:7295");
            client.BaseAddress = baseAdress;

            ArrayList vendacompleta = new ArrayList();
            Venda venda = new Venda {};
            Vendedor vendedor = new Vendedor {};
            Item item = new Item{};
            vendacompleta.Add(venda);
            vendacompleta.Add(vendedor);
            vendacompleta.Add(item);
            
            HttpResponseMessage response = client.PostAsJsonAsync("api/product/SupplierAndProduct", vendacompleta).Result;

            
            if (venda.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da venda não pode ser vazia" });

            // DONE: Adicionar a venda recebida no EF e salvar as mudanças (save changes)
          //O Status será Aguardando Pagamento  
            venda.Status = 0; 
            _context.Add(vendedor);
            _context.Add(venda);
            _context.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { idVenda = venda.VendaId }, venda);
        }                   
        */
    }
}
