using ApiEcommerce.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class CarrinhoModel
    {
        [Key]
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int? IdUsuario { get; set; }
    }
}
