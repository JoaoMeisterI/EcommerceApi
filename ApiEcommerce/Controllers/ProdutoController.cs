using ApiEcommerce.Models;
using ApiEcommerce.Service.Produto;
using Microsoft.AspNetCore.Mvc;


namespace ApiEcommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetProdutoAll()
    {
        return Ok(await _produtoService.GetProdutosAll());
    }

    [HttpGet("produto/{categoria}")]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetProdutoByCategoria(string categoria)
    {
        return Ok(await _produtoService.GetProdutosByCategoria(categoria));
    }

    [HttpGet("categorias")]
    public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetCategoriasProduto()
    {
        return Ok(await _produtoService.GetCategoriasProduto());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetProdutoById(int id)
    {
        return Ok(await _produtoService.GetProdutoById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> CreateProduto(ProdutoModel novoProduto)
    {
        return Ok(await _produtoService.CreateProduto(novoProduto));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> UpdateProduto(ProdutoModel produtoAtualizado)
    {
        return Ok(await _produtoService.UpdateProduto(produtoAtualizado));
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> DeleteProduto(int id)
    {
        return Ok(await _produtoService.DeleteProduto(id));
    }

}


