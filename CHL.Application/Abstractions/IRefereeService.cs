using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface IRefereeService
{
    public Task<string> Create(RefereeDTO model);
    public Task<string> Update(Guid id, RefereeDTO model);
    public Task<string> Delete(Guid id);
    public Task<RefereeResponseDTO> GetById(Guid id);
    public Task<List<RefereeResponseDTO>> GetAll();
}