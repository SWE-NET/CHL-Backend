using CHL.Domain.DTOs;
using CHL.Domain.Models;

namespace CHL.Application.Abstractions;

public interface IUserService
{
    public Task<string> Create(UserDTO model);
    public Task<string> Update(Guid id, UserDTO model);
    public Task<string> Delete(Guid id);
    public Task<User> GetById(Guid id);
    public Task<List<User>> GetAll();
}