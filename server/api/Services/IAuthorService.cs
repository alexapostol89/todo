using api.Dtos;
using efscaffold;
using Microsoft.AspNetCore.Mvc;

namespace api.Services;

public interface IAuthorService
{
    Task<Author> CreateAuthor(CreateAuthorDto dto);
    Task<List<Author>> GetAllAuthors();
    //Task DeleteAllAuthors();

}