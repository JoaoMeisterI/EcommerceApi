using System.Text.Json.Serialization;

namespace ApiEcommerce.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum User
    {
        Administrador,
        Padrao,
    }
}
