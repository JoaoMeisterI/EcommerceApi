using ApiEcommerce.DataContext;
using ApiEcommerce.Models;
using ApiEcommerce.Service.Produto;
using ApiEcommerce.Service.Usuario;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Service.Carrinho;

public class CarrinhoService : ICarrinhoService
{
	private readonly DbApplicationContext _context;
    private readonly IProdutoService _produto;
	private readonly IUsuarioService _usuario;
    public CarrinhoService(DbApplicationContext context,IProdutoService produto,IUsuarioService usuario)
	{
		_context = context;
		_produto = produto;
		_usuario = usuario;
	}

	public async Task<ServiceResponse<List<CarrinhoModel>>> CreateCarrinho(CarrinhoModel carrinho)
	{
		if(carrinho==null)
		{
			return ServiceResponse<List<CarrinhoModel>>.GerarResposta(null, "Produto Está Nulo", false);
		}

		try
		{
			await _context.Carrinho.AddAsync(carrinho);
			await _context.SaveChangesAsync();
			List<CarrinhoModel> listaCarrinho = await _context.Carrinho.ToListAsync();
			return ServiceResponse<List<CarrinhoModel>>.GerarResposta(listaCarrinho);

		}
        catch (Exception ex)
        {
            return ServiceResponse<List<CarrinhoModel>>.GerarResposta(null, ex.Message, false);
        }
    }

    public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutosCarrinhoByUser(int userId)
    {
		if (userId == 0) return ServiceResponse<ProdutoModel>.CriarRespostaErro("Usuário está nulo");

        try
		{
			ServiceResponse<UsuarioModel> usuario = await _usuario.GetUsuarioById(userId);
            
			List<ProdutoModel> listaProdutos = new List<ProdutoModel>();

            if (usuario.Sucesso==false) return ServiceResponse<ProdutoModel>.CriarRespostaErro("Não Foi Possivel Encontrar o Usuário");

            List<int> idsProduto = await _context.Carrinho
					.Where(carrinho => carrinho.IdUsuario == usuario.Dados.Id && carrinho.IdProduto > 0)
					.Select(carrinho => carrinho.IdProduto)
					.Distinct()
					.ToListAsync();
			
			if(!idsProduto.Any()) return ServiceResponse<ProdutoModel>.CriarRespostaErro("Não Foi Possivel Encontrar os Ids dos Produtos");

			listaProdutos = await _context.Produto
				.Where(produto => idsProduto.Contains(produto.Id))
				.ToListAsync();

			listaProdutos.ForEach(Produto => Produto.ImagemBase64 = Utils.Utils.ConvertVarbinaryToBase64(Produto.Imagem));
            
            string mensagemRetorno = listaProdutos.Any() ? "" : "Lista Não Possui Produtos";

            return ServiceResponse<List<ProdutoModel>>.GerarResposta(listaProdutos, mensagemRetorno);

        }
		catch (Exception ex)
		{
            return ServiceResponse<List<ProdutoModel>>.GerarResposta(null, ex.Message, false);
		}
    }
};
