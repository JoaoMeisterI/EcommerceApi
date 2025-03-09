using ApiEcommerce.Models;
using ApiEcommerce.Service.Produto;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrinhoController : ControllerBase
{
    public ICarrinhoService _carrinhoService;

    public CarrinhoController(ICarrinhoService carrinhoService)
    {
        _carrinhoService = carrinhoService;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CarrinhoModel>>>> CreateCarrinho(CarrinhoModel carrinho)
    {
        return Ok(await _carrinhoService.CreateCarrinho(carrinho));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetCarrinhoByUser(int userId)
    {
        return Ok(await _carrinhoService.GetProdutosCarrinhoByUser(userId));
    }
}
