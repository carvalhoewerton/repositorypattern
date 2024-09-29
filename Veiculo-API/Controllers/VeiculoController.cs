using Microsoft.AspNetCore.Mvc;
using Veiculo_API.Dominio;
using Veiculo_API.Infra.Repositories.Interfaces;

namespace Veiculo_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly ILogger<VeiculoController> _logger;


    public VeiculoController(IUnityOfWork unityOfWork, ILogger<VeiculoController> logger)
    {
        _unityOfWork = unityOfWork;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unityOfWork.Veiculos.All());
    }

    [HttpPost]
    public async Task<IActionResult> Salvar([FromBody] Veiculo veiculo)
    {
        if (veiculo == null)
        {
            return BadRequest("Veiculo não pode ser nulo.");
            
        }
        await _unityOfWork.Veiculos.Add(veiculo); 
        await _unityOfWork.CompleteAsync(); 
        return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var veiculo = await _unityOfWork.Veiculos.GetById(id);
        await _unityOfWork.CompleteAsync();
        return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Veiculo veiculoAtualizado)
    {
        if (veiculoAtualizado == null)
        {
            return BadRequest("Os dados do veículo não podem ser nulos.");
        }

        var veiculoExistente = await _unityOfWork.Veiculos.GetById(id);
    
        if (veiculoExistente == null)
        {
            return NotFound(); 
        }
        veiculoExistente.Nome = veiculoAtualizado.Nome;
        veiculoExistente.Marca = veiculoAtualizado.Marca;
        veiculoExistente.Ano = veiculoAtualizado.Ano;
        await _unityOfWork.CompleteAsync(); 
        return Ok(veiculoExistente); 
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var veiculo = await _unityOfWork.Veiculos.GetById(id);
        if (veiculo == null)
        {
            return NotFound();
        }
        await _unityOfWork.CompleteAsync();
        return Ok();
    }

    [HttpGet("{id}/string")]
    public async Task<IActionResult> GetString([FromRoute] int id)
    {
        var veiculo = await _unityOfWork.Veiculos.GetById(id);
        var frase = veiculo.Marca + " "+ veiculo.Nome + " " +  "do ano" + " " + veiculo.Ano;
        return Ok(frase);
    }
}