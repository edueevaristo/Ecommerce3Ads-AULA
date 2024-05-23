using System.ComponentModel.DataAnnotations;

namespace Ecommerce3Ads.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string NomePlataforma { get; set; }

        public DateTime DataPedido { get; set; }

        public bool Pago { get; set; }

        public string NomeComprador { get; set; }

        public string CpfComprador { get; set; }

        public string EnderecoComprador { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public Pedido(string nomePlataforma, DateTime dataPedido, bool pago, string nomeComprador, string cpfComprador, string enderecoComprador, int produtoId)
        {
            NomePlataforma = nomePlataforma;
            DataPedido = dataPedido;
            Pago = pago;
            NomeComprador = nomeComprador;
            CpfComprador = cpfComprador;
            EnderecoComprador = enderecoComprador;
            ProdutoId = produtoId;
        }

    }
}
