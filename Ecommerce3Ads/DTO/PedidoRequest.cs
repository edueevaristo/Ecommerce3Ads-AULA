using Ecommerce3Ads.Model;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce3Ads.DTO
{
    public class PedidoRequest
    {
        public string NomePlataforma { get; set; }

        public DateTime DataPedido { get; set; }

        public bool Pago { get; set; }

        public string NomeComprador { get; set; }

        public string CpfComprador { get; set; }

        public string EnderecoComprador { get; set; }

        public int ProdutoId { get; set; }

        public Pedido toModel()
            => new Pedido(NomePlataforma, DataPedido, Pago, NomeComprador, CpfComprador, EnderecoComprador, ProdutoId);
    }
}
