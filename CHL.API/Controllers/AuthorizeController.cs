using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CHL.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthorizeController : Controller
{
    private readonly IJWTService _jwt;

    public AuthorizeController(IJWTService jwt)
    {
        _jwt = jwt;
    }


    [HttpPost]
    public async Task<ActionResult<ResponseDTO>> Login([FromBody] LoginDTO model)
    {
        var result = await _jwt.Login(model);

        return result;
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Register(UserDTO model)
    {
        var result = _jwt.Register(model);

        return Ok(new { Message = result });
    }
    
}