using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface ISceneService
{
    public Task<string> Create(SceneDTO model);
    public Task<string> Update(Guid id, SceneDTO model);
    public Task<string> Delete(Guid id);
    public Task<SceneResponseDTO> GetById(Guid id);
    public Task<List<SceneResponseDTO>> GetAll();
}