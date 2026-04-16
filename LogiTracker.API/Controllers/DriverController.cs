using LogiTracker.Application.DTOs;
using LogiTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiTracker.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de motoristas na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly IDriverRepository _driverRepository;

    public DriverController(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    /// <summary>
    /// Lista todos os motoristas cadastrados.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var drivers = _driverRepository.GetAll();
        return Ok(drivers);
    }

    /// <summary>
    /// Busca um motorista pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var driver = _driverRepository.GetById(id);
        if (driver is null)
            return NotFound();

        return Ok(driver);
    }

    /// <summary>
    /// Cria um novo motorista.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] DriverRequest request)
    {
        try
        {
            var driver = _driverRepository.Create(request);
            return Ok(driver);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um motorista pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_driverRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}
