using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface IPlayerService
{
    public Task<string> Create(PlayerDTO model);
    public Task<string> Update(Guid id, PlayerDTO model);
    public Task<string> Delete(Guid id);
    public Task<PlayerResponseDTO> GetById(Guid id);
    public Task<List<PlayerResponseDTO>> GetAll();
}