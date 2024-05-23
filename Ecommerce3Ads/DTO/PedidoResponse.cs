using Ecommerce3Ads.Model;

namespace Ecommerce3Ads.DTO
{
    public class PedidoResponse
    {
        public string NomePlataforma { get; set; }

        public DateTime DataPedido { get; set; }

        public bool Pago { get; set; }

        public string NomeComprador { get; set; }

        public string CpfComprador { get; set; }

        public string EnderecoComprador { get; set; }

        public int ProdutoId { get; set; }

        public PedidoResponse(Pedido pedido)
        {
            NomePlataforma = pedido.NomePlataforma;
            DataPedido = pedido.DataPedido;
            Pago = pedido.Pago;
            NomeComprador = pedido.NomeComprador;
            CpfComprador = pedido?.CpfComprador;
            EnderecoComprador = pedido.CpfComprador;
            ProdutoId = pedido.ProdutoId;
        }
    }
}
