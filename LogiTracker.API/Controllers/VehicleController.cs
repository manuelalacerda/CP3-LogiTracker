using LogiTracker.Application.DTOs;
using LogiTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiTracker.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de veículos na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    /// <summary>
    /// Lista todos os veículos cadastrados.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var vehicles = _vehicleRepository.GetAll();
        return Ok(vehicles);
    }

    /// <summary>
    /// Busca um veículo pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var vehicle = _vehicleRepository.GetById(id);
        if (vehicle is null)
            return NotFound();

        return Ok(vehicle);
    }

    /// <summary>
    /// Cria um novo veículo.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] VehicleRequest request)
    {
        try
        {
            var vehicle = _vehicleRepository.Create(request);
            return Ok(vehicle);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um veículo pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_vehicleRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}
