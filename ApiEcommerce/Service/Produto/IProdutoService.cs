using ApiEcommerce.Models;

namespace ApiEcommerce.Service.Produto
{
    public interface IProdutoService
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutosAll();
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutosByCategoria(string categoria);
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int idProduto);
        Task<ServiceResponse<List<string>>> GetCategoriasProduto();
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel produtoEditado);
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int idProduto);
    }
}
