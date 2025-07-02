using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface ITeamService
{
    public Task<string> Create(TeamDTO model);
    public Task<string> Update(Guid id, TeamDTO model);
    public Task<string> Delete(Guid id);
    public Task<TeamResponseDTO> GetById(Guid id);
    public Task<List<TeamResponseDTO>> GetAll();
}