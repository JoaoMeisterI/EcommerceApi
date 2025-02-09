using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiEcommerce.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string DescricaoProduto { get; set; }
        public string Cor { get; set; }
        public float PrecoPago { get; set; }
        public float PrecoVenda { get; set; }
        public string Tamanho { get; set; }
        public int QuantidadeEstoque { get; set; }
        public byte[]? Imagem { get; set; }
        public string? CategoriaProduto { get; set; }
        public string? CondicaoProduto { get; set; }
    }
}
