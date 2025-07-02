using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;

namespace CHL.Application.Abstractions;

public interface INewsService
{
    public Task<string> Create(NewsDTO model);
    public Task<string> Update(Guid id, NewsDTO model);
    public Task<string> Delete(Guid id);
    public Task<NewsResponseDTO> GetById(Guid id);
    public Task<List<NewsResponseDTO>> GetAll();
}