using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CHL.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class NewsController : Controller
{
    private readonly INewsService _service;

    public NewsController(INewsService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<string>> Create(NewsDTO model)
    {
        var result = await _service.Create(model);

        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return Ok(new { Message = result });
    }


    [HttpPut]
    public async Task<ActionResult<string>> Update(Guid id, NewsDTO model)
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
    public async Task<ActionResult<NewsResponseDTO>> GetById(Guid id)
    {
        var result = await _service.GetById(id);
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return result;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<NewsResponseDTO>>> GetAll()
    {
        var result = await _service.GetAll();
        
        if (result == null)
        {
            return BadRequest(new { Message = "404 Not Found" });
        }

        return result;
    }
}