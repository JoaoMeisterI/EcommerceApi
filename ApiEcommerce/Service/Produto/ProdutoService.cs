using ApiEcommerce.DataContext;
using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Service.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly DbApplicationContext _context;

        public ProdutoService(DbApplicationContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
        {
            if (novoProduto == null)
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, "Produto Está Nulo", false);

            try
            {
                await _context.Produto.AddAsync(novoProduto);
                await _context.SaveChangesAsync();
                List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();

                return ServiceResponse<List<ProdutoModel>>.GerarResposta(produtoList);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int idProduto)
        {
            try
            {
                ProdutoModel? produto = await _context.Produto.FindAsync(idProduto);

                if (produto == null)
                    return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, "Produto Não Encontrado", false);

                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();
                List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();

                return ServiceResponse<List<ProdutoModel>>.GerarResposta(produtoList);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutosAll()
        {
            try
            {
                List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();
                produtoList.ForEach(produto => produto.ImagemBase64 = Utils.Utils.ConvertVarbinaryToBase64(produto.Imagem));

                string? mensagem = produtoList.Count == 0 ? "Sem Produtos cadastrados" : null;
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(produtoList, mensagem);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int idProduto)
        {
            try
            {
                ProdutoModel? produto = await _context.Produto.FindAsync(idProduto);

                if (produto == null)
                    return ServiceResponse<ProdutoModel>.GerarResposta(null, $"Não foi encontrado o produto do ID {idProduto}", false);

                produto.ImagemBase64 = Utils.Utils.ConvertVarbinaryToBase64(produto.Imagem);
                return ServiceResponse<ProdutoModel>.GerarResposta(produto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProdutoModel>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel produtoEditado)
        {
            if (produtoEditado == null)
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, "Produto Não Pode Estar Vazio", false);

            try
            {
                ProdutoModel? produto = await _context.Produto.FindAsync(produtoEditado.Id);

                if (produto == null)
                    return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, "Produto Não Encontrado", false);

                _context.Entry(produto).CurrentValues.SetValues(produtoEditado);
                await _context.SaveChangesAsync();

                List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(produtoList, "Sucesso", true);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<string>>> GetCategoriasProduto()
        {
            try
            {
                List<string?> produtoList = await _context.Produto
                    .Where(produto => !string.IsNullOrEmpty(produto.CategoriaProduto))
                    .Select(produto => produto.CategoriaProduto)
                    .Distinct()
                    .ToListAsync();

                if (produtoList.Count == 0)
                    return ServiceResponse<List<string>>.GerarResposta(null, "Sem Categorias Cadastradas", false);

                return ServiceResponse<List<string>>.GerarResposta(produtoList);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<string>>.GerarResposta(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutosByCategoria(string categoria)
        {
            try
            {
                List<ProdutoModel> produtos = await _context.Produto
                    .Where(produto => produto.CategoriaProduto == categoria)
                    .ToListAsync();

                produtos.ForEach(produto => produto.ImagemBase64 = Utils.Utils.ConvertVarbinaryToBase64(produto.Imagem));

                return ServiceResponse<List<ProdutoModel>>.GerarResposta(produtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
            }
        }
    }
}
