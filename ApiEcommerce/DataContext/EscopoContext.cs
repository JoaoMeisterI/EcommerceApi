using ApiEcommerce.Service.Carrinho;
using ApiEcommerce.Service.Produto;
using ApiEcommerce.Service.Usuario;

namespace ApiEcommerce.DataContext
{
    public class EscopoContext
    {
        public static void AddClassesEscopo(IServiceCollection service)
        {
            service.AddScoped<IProdutoService, ProdutoService>();
            service.AddScoped<IUsuarioService, UsuarioService>();
            service.AddScoped<ICarrinhoService, CarrinhoService>();

        }

    }
}
