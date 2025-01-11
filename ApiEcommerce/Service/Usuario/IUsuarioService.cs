using ApiEcommerce.Models;

namespace ApiEcommerce.Service.Usuario
{
    public interface IUsuarioService
    {
        Task<ServiceResponse<List<UsuarioModel>>> GetUsuariosAll();
        Task<ServiceResponse<UsuarioModel>> GetUsuarioById(int idUsuario);
        Task<ServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario);
        Task<ServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel usuarioEditado);
        Task<ServiceResponse<List<UsuarioModel>>> DeleteUsuario(int idUsuario);
    }
}
