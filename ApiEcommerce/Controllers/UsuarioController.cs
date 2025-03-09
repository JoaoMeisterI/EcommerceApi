using ApiEcommerce.Models;
using ApiEcommerce.Service.Usuario;
using Microsoft.AspNetCore.Mvc;


namespace ApiEcommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> GetUsuarioAll()
    {
        return Ok(await _usuarioService.GetUsuariosAll());
    }

    [HttpGet("tentativaAcesso")]
    public async Task<ActionResult<ServiceResponse<UsuarioModel>>> GetUsuarioByCredenciais(string user, string senha)
    {
        return Ok(await _usuarioService.GetUsuarioByCredenciais(user,senha));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> CreateUsuario(UsuarioModel novoUsuario)
    {
        return Ok(await _usuarioService.CreateUsuario(novoUsuario));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> UpdateUsuario(UsuarioModel UsuarioAtualizado)
    {
        return Ok(await _usuarioService.UpdateUsuario(UsuarioAtualizado));
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> DeleteUsuario(int id)
    {
        return Ok(await _usuarioService.DeleteUsuario(id));
    }

}


