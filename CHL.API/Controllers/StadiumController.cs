using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CHL.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StadiumController : Controller
{
    private readonly IStadiumService _service;

    public StadiumController(IStadiumService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<string>> Create(StadiumDTO model)
    {
        var result = await _service.Create(model);

        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return Ok(new { Message = result });
    }


    [HttpPut]
    public async Task<ActionResult<string>> Update(Guid id, StadiumDTO model)
    {
        var result = await _service.Update(id, model);
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return Ok(new { Message = result });
    }


    [HttpDelete]
    public async Task<ActionResult<string>> Delete(Guid id)
    {
        var result = await _service.Delete(id);
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return Ok(new { Message = result });
    }


    [HttpGet]
    public async Task<ActionResult<StadiumResponseDTO>> GetById(Guid id)
    {
        var result = await _service.GetById(id);
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return result;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<StadiumResponseDTO>>> GetAll()
    {
        var result = await _service.GetAll();
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return result;
    }
}