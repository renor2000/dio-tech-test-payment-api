using System.ComponentModel;

namespace TrilhaApiDesafio.Models
{
    public enum EnumStatusVenda
    {
        [Description("Aguardando Pagamento")]
        AguardandoPagamento = 1,
        [Description("Pagamento Aprovado")]
        PagamentoAprovado = 2,
        [Description("Enviado para a Transportadora")]
        EnviadoParaATransportadora = 3,
        [Description("Entregue")]
        Entregue = 4,
        [Description("Cancelada")]
        Cancelada = 5
    }
}