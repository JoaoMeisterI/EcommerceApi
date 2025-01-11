namespace ApiEcommerce.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string MensagemRetorno { get; set; }
        public bool Sucesso { get; set; }
    }
}
