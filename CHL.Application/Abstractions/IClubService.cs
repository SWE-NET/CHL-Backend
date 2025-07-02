using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface IClubService
{
    public Task<string> Create(ClubDTO model);
    public Task<string> Update(Guid id, ClubDTO model);
    public Task<string> Delete(Guid id);
    public Task<ClubResponseDTO> GetById(Guid id);
    public Task<List<ClubResponseDTO>> GetAll();
}