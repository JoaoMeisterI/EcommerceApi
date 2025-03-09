using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.DataContext
{
    public class DbApplicationContext : DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> opcoes) : base(opcoes)
        {

        }
        public DbSet<ProdutoModel> Produto {get;set;}
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<CarrinhoModel> Carrinho { get; set; }
    }
}
