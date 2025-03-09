using ApiEcommerce.Models;

namespace ApiEcommerce.Service.Produto
{
    public interface ICarrinhoService
    {
        Task<ServiceResponse<List<CarrinhoModel>>> CreateCarrinho(CarrinhoModel carrinho);
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutosCarrinhoByUser(int userId);
    }
}
