using CHL.Domain.DTOs;
using CHL.Domain.Models;

namespace CHL.Application.Abstractions;

public interface IRefereeService
{
    public Task<string> Create(RefereeDTO model);
    public Task<string> Update(Guid id, RefereeDTO model);
    public Task<string> Delete(Guid id);
    public Task<Referee> GetById(Guid id);
    public Task<List<Referee>> GetAll();
}