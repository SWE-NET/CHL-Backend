using CHL.Domain.DTOs;

namespace CHL.Application.Abstractions;

public interface IJWTService
{
    public Task<ResponseDTO> Login(LoginDTO model);
    public Task<string> Register(UserDTO model);
}