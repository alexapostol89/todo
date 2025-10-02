using api.Dtos;
using api.Services;
using efscaffold;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]

public class MainController(IAuthorService authorService) : ControllerBase
{
    [Route(nameof(GetAllAuthors))]
    [HttpGet]
    public async Task<ActionResult<List<Author>>> GetAllAuthors()
    {
        var authors = await authorService.GetAllAuthors();
        return authors;
        
    }
    [Route(nameof(CreateAuthor))]
    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor([FromBody]CreateAuthorDto dto)
    {

        var result = await authorService.CreateAuthor(dto);
        return result;
    }
    
/*[HttpDelete("DeleteAllAuthors")]
    public async Task<IActionResult> DeleteAllAuthors()
    {
        await authorService.DeleteAllAuthors();
        return NoContent();
    }*/
    
    
    
}