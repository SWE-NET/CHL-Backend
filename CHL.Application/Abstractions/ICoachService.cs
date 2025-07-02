using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface ICoachService
{
    public Task<string> Create(CoachDTO model);
    public Task<string> Update(Guid id, CoachDTO model);
    public Task<string> Delete(Guid id);
    public Task<CoachResponseDTO> GetById(Guid id);
    public Task<List<CoachResponseDTO>> GetAll();
}