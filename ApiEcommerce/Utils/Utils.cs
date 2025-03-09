namespace ApiEcommerce.Utils
{
    public class Utils
    {
        public static string ConvertVarbinaryToBase64(byte[] varbinaryData)
        {
            // Verifica se os dados são nulos
            if (varbinaryData == null)
            {
                return null;
            }

            // Converte os dados binários para uma string Base64
            return Convert.ToBase64String(varbinaryData);
        }
    }
}
