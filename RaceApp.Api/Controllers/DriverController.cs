using Microsoft.AspNetCore.Mvc;
using RaceApp.Api.Exceptions;
using RaceApp.Api.Interfaces;
using RaceApp.Api.Models;

namespace RaceApp.Api.Controllers;

[ApiVersion("1")]
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly IDriverRepository _repo;
    public DriverController(IDriverRepository repo)
    {
        _repo = repo;
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult> CreateItem([FromBody] Driver newDriver)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var driver = await _repo.AddAsync(newDriver);
        return Ok(driver);
    }

    [HttpGet("{driver}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Driver))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetItem(string driverId)
    {
        try
        {
            var toDo = await _repo.GetByIdAsync(driverId);
            return Ok(toDo);
        }
        catch (EntityNotFoundException)
        {
            return NotFound(driverId);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{driverId}")]
    public async Task<ActionResult> UpdateItem(string driverId, [FromBody] Driver updatedDriver)
    {
        if (updatedDriver.Id != driverId)
            return BadRequest(updatedDriver.Id);
        
        try
        {
            if (driverId == null)
                return NotFound(driverId);
            
            await _repo.UpdateAsync(updatedDriver);
            return Ok();
        }
        catch (EntityNotFoundException)
        {
            return NotFound(driverId);
        }
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{driverId}")]
    public async Task<ActionResult> RemoveItem(string driverId)
    {
        try
        {
            var driverUpdate = await _repo.GetByIdAsync(driverId);

            if (driverUpdate == null)
                return NotFound(driverId);
            
            await _repo.DeleteAsync(driverUpdate);
            return NoContent();
        }
        catch (EntityNotFoundException)
        {
            return NotFound(driverId);
        }
    }
}
