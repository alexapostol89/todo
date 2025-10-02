using api.Dtos;
using efscaffold;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class AuthorService : IAuthorService
{
    private readonly MyDbContext dbContext;

    public AuthorService(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Author> CreateAuthor(CreateAuthorDto dto)
    {
        var myAuthor = new Author
        {
            Name = dto.Name,
        };

        dbContext.Authors.Add(myAuthor);
        await dbContext.SaveChangesAsync();
        return myAuthor;
    }

    public async Task<List<Author>> GetAllAuthors()
    {
        return await dbContext.Authors.ToListAsync();
    }
/*public async Task DeleteAllAuthors()
    {
        dbContext.Authors.RemoveRange(dbContext.Authors);
        await dbContext.SaveChangesAsync();
    }*/
    
}