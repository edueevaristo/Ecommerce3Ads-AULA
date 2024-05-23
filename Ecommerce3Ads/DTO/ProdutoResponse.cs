using Ecommerce3Ads.Model;

namespace Ecommerce3Ads.DTO
{
    public class ProdutoResponse
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }

        public ProdutoResponse(Produto produto)
        {
            Nome = produto.Nome;
            CategoriaId = produto.CategoriaId;
        }
    }
}
