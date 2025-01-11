using ApiEcommerce.Models;

namespace ApiEcommerce.Service.Produto
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutosAll();
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int idProduto);
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel produtoEditado);
        //Task<ServiceResponse<List<ProdutoModel>>> UpdateEstoqueProduto(); fazer depois
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int idProduto);
    }
}
