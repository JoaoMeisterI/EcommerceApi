using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Cor { get; set; }
        public float PrecoPago { get; set; }
        public float PrecoVenda { get; set; }
        public string Tamanho { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Imagem { get; set; } //Validar
    }
}
