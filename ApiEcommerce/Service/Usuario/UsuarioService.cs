using ApiEcommerce.DataContext;
using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbApplicationContext _context;
        public UsuarioService(DbApplicationContext context)
        {
            _context = context;
        }

        private static ServiceResponse<T> GerarResposta<T>(T dados, string mensagemRetorno = null, bool sucesso = true)
        {
            return new ServiceResponse<T>
            {
                Dados = dados,
                MensagemRetorno = mensagemRetorno,
                Sucesso = sucesso
            };
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario)
        {
            if (novoUsuario == null) return GerarResposta<List<UsuarioModel>>(null, "Usuário está nulo", false);

            try
            {
                await _context.Usuario.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();
                List<UsuarioModel> usuarioList = await _context.Usuario.ToListAsync();

                return GerarResposta(usuarioList);
            }
            catch (Exception ex)
            {
                return GerarResposta<List<UsuarioModel>>(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> DeleteUsuario(int idUsuario)
        {
            try
            {
                UsuarioModel? usuario = await _context.Usuario.FindAsync(idUsuario);

                if (usuario == null) return GerarResposta<List<UsuarioModel>>(null, "Usuário não encontrado", false);

                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                List<UsuarioModel> usuarioList = await _context.Usuario.ToListAsync();

                return GerarResposta(usuarioList);
            }
            catch (Exception ex)
            {
                return GerarResposta<List<UsuarioModel>>(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> GetUsuariosAll()
        {
            try
            {
                List<UsuarioModel> usuarioList = await _context.Usuario.ToListAsync();
                string? mensagem = usuarioList.Count == 0 ? "Sem usuários cadastrados" : null;
                return GerarResposta(usuarioList);
            }
            catch (Exception ex)
            {
                return GerarResposta<List<UsuarioModel>>(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<UsuarioModel>> GetUsuarioById(int idUsuario)
        {
            try
            {
                UsuarioModel? usuario = await _context.Usuario.FindAsync(idUsuario);
                if (usuario == null)
                {
                    return GerarResposta<UsuarioModel>(null, $"Não foi encontrado o usuário com ID {idUsuario}", false);
                }
                return GerarResposta(usuario);
            }
            catch (Exception ex)
            {
                return GerarResposta<UsuarioModel>(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<UsuarioModel>> GetUsuarioByCredenciais(string user, string senha)
        {
            try
            {
                UsuarioModel? usuario = await _context.Usuario.FirstAsync(usuarioAcesso => usuarioAcesso.User == user && usuarioAcesso.Senha == senha);
                if (usuario == null)
                {
                    return GerarResposta<UsuarioModel>(null, $"Usuário ou Senha Inválidos {user}", false);
                }
                return GerarResposta(usuario);
            }
            catch (Exception ex)
            {
                return GerarResposta<UsuarioModel>(null, ex.Message, false);
            }
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel usuarioEditado)
        {
            if (usuarioEditado == null) return GerarResposta<List<UsuarioModel>>(null, "Usuário não pode estar vazio", false);

            try
            {
                UsuarioModel? usuario = await _context.Usuario.FindAsync(usuarioEditado.Id);

                if (usuario == null) return GerarResposta<List<UsuarioModel>>(null, "Usuário não encontrado", false);

                _context.Entry(usuario).CurrentValues.SetValues(usuarioEditado);
                await _context.SaveChangesAsync();

                List<UsuarioModel> usuarioList = await _context.Usuario.ToListAsync();
                return GerarResposta(usuarioList, "Atualização realizada com sucesso", true);
            }
            catch (Exception ex)
            {
                return GerarResposta<List<UsuarioModel>>(null, ex.Message, false);
            }
        }
    }
}
