using LogiTracker.Application.DTOs;
using LogiTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiTracker.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de transportadoras na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarrierController : ControllerBase
{
    private readonly ICarrierRepository _carrierRepository;

    public CarrierController(ICarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
    }

    /// <summary>
    /// Lista todas as transportadoras cadastradas.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var carriers = _carrierRepository.GetAll();
        return Ok(carriers);
    }

    /// <summary>
    /// Busca uma transportadora pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var carrier = _carrierRepository.GetById(id);
        if (carrier is null)
            return NotFound();

        return Ok(carrier);
    }

    /// <summary>
    /// Cria uma nova transportadora.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] CarrierRequest request)
    {
        try
        {
            var carrier = _carrierRepository.Create(request);
            return Ok(carrier);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove uma transportadora pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_carrierRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}
