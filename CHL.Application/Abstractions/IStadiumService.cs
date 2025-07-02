using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface IStadiumService
{
    public Task<string> Create(StadiumDTO model);
    public Task<string> Update(Guid id, StadiumDTO model);
    public Task<string> Delete(Guid id);
    public Task<StadiumResponseDTO> GetById(Guid id);
    public Task<List<StadiumResponseDTO>> GetAll();
}