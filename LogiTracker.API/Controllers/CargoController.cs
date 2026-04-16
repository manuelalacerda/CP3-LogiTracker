using LogiTracker.Application.DTOs;
using LogiTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiTracker.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de cargas na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CargoController : ControllerBase
{
    private readonly ICargoRepository _cargoRepository;

    public CargoController(ICargoRepository cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    /// <summary>
    /// Lista todas as cargas cadastradas.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var cargos = _cargoRepository.GetAll();
        return Ok(cargos);
    }

    /// <summary>
    /// Busca uma carga pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var cargo = _cargoRepository.GetById(id);
        if (cargo is null)
            return NotFound();

        return Ok(cargo);
    }

    /// <summary>
    /// Cria uma nova carga.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] CargoRequest request)
    {
        try
        {
            var cargo = _cargoRepository.Create(request);
            return Ok(cargo);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove uma carga pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_cargoRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}
