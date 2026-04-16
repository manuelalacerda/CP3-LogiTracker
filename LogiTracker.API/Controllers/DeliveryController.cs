using LogiTracker.Application.DTOs;
using LogiTracker.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiTracker.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de entregas na API.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DeliveryController : ControllerBase
{
    private readonly IDeliveryRepository _deliveryRepository;

    public DeliveryController(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }

    /// <summary>
    /// Lista todas as entregas cadastradas.
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var deliveries = _deliveryRepository.GetAll();
        return Ok(deliveries);
    }

    /// <summary>
    /// Busca uma entrega pelo identificador único.
    /// </summary>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var delivery = _deliveryRepository.GetById(id);
        if (delivery is null)
            return NotFound();

        return Ok(delivery);
    }

    /// <summary>
    /// Cria uma nova entrega.
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] DeliveryRequest request)
    {
        try
        {
            var delivery = _deliveryRepository.Create(request);
            return Ok(delivery);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove uma entrega pelo identificador único.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_deliveryRepository.Delete(id))
            return NotFound();

        return NoContent();
    }
}
