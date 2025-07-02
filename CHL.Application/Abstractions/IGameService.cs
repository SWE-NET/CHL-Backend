using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface IGameService
{
    public Task<string> Create(GameDTO model);
    public Task<string> Update(Guid id, GameDTO model);
    public Task<string> Delete(Guid id);
    public Task<GameResponseDTO> GetById(Guid id);
    public Task<List<GameResponseDTO>> GetAll();
}