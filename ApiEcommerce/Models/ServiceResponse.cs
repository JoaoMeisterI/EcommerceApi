
namespace ApiEcommerce.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string MensagemRetorno { get; set; }
        public bool Sucesso { get; set; }

        public static ServiceResponse<T> GerarResposta(T dados, string mensagemRetorno = null, bool sucesso = true)
        {
            return new ServiceResponse<T>
            {
                Dados = dados,
                MensagemRetorno = mensagemRetorno,
                Sucesso = sucesso
            };
        }

        public static ServiceResponse<List<T>> CriarRespostaErro(string mensagem)
        => ServiceResponse<List<T>>.GerarResposta(null, mensagem, false);


    }
}
