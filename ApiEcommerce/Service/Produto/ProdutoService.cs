using ApiEcommerce.DataContext;
using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Service.Produto;

public class ProdutoService : IProdutoService
{
    private readonly DbApplicationContext _context;
    public ProdutoService(DbApplicationContext context)
    {
        _context = context;
    }

    private static ServiceResponse<T> GerarResposta<T>(T dados, string mensagemRetorno = null, bool sucesso = true)
    {
        return new ServiceResponse<T>
        {
            Dados = dados,
            MensagemRetorno = mensagemRetorno,
            Sucesso = sucesso
        };
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
    {
        if (novoProduto == null) return GerarResposta<List<ProdutoModel>>(null, "Produto Está Nulo", false);
        //PENSAR EM FAZER UM MÉTODO DE VALIDAÇÃO AQUI FUTURAMENTE
        try
        {
            await _context.Produto.AddAsync(novoProduto);
            await _context.SaveChangesAsync();
            List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();

            return GerarResposta(produtoList);
        }
        catch (Exception ex)
        {
            return GerarResposta<List<ProdutoModel>>(null, ex.Message, false);
        }
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int idProduto)
    {
        try
        {
            ProdutoModel? produto = await _context.Produto.FindAsync(idProduto);

            if (produto == null) return GerarResposta<List<ProdutoModel>>(null, "Produto Não Encontrado", false);

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();

            return GerarResposta(produtoList);
        }
        catch (Exception ex)
        {
            return GerarResposta<List<ProdutoModel>>(null, ex.Message, false);
        }
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutosAll()
    {
        try
        {
            List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();
            string? mensagem = produtoList.Count == 0 ? "Sem Produtos cadastrados" : null;
            return GerarResposta(produtoList);
        }
        catch (Exception ex)
        {
            return GerarResposta<List<ProdutoModel>>(null, ex.Message, false);
        }
    }
    public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int idProduto)
    {
        try
        {
            ProdutoModel? produto = await _context.Produto.FindAsync(idProduto);
            if (produto == null)
            {
                return GerarResposta<ProdutoModel>(null, $"Não foi encontrado o produto do ID {idProduto}", false);
            }
            return GerarResposta(produto);
        }
        catch (Exception ex)
        {
            return GerarResposta<ProdutoModel>(null, ex.Message, false);
        }
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel produtoEditado)
    {
        if (produtoEditado == null) return GerarResposta<List<ProdutoModel>>(null, "Produto Não Pode Estar Vazio", false);

        try
        {
            ProdutoModel? produto = await _context.Produto.FindAsync(produtoEditado.Id);

            if (produto == null) return GerarResposta<List<ProdutoModel>>(null, "Produto Não Encontrado", false);

            _context.Entry(produto).CurrentValues.SetValues(produtoEditado);
            await _context.SaveChangesAsync();

            List<ProdutoModel> produtoList = await _context.Produto.ToListAsync();
            return GerarResposta(produtoList,"Sucesso",true);


        }
        catch (Exception ex)
        {
            return GerarResposta<List<ProdutoModel>>(null, ex.Message, false);
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

            if (produtoList.Count == 0) return GerarResposta<List<string>>(null,"Sem Categorias Cadastradas",false);

            return GerarResposta(produtoList);
        }
        catch (Exception ex)
        {
            return GerarResposta<List<string>>(null, ex.Message, false);
        }
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutosByCategoria(string categoria)
    {
        try
        {
            List<ProdutoModel> produtos = await _context.Produto
                .Where(produto => produto.CategoriaProduto == categoria)
                .ToListAsync();


        }
        catch (Exception)
        {

            throw;
        }
    }
}
