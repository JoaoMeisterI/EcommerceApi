using ApiEcommerce.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string MetodoPagamento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public User TipoUser { get; set; }
    }
}
