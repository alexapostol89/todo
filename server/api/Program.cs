using System.Text.Json;
using api;
using efscaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);





builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    
    conf.UseNpgsql(appOptions.DbConnectionString);
});


var app = builder.Build();

app.MapGet("/", (
    
    [FromServices]IOptionsMonitor<AppOptions> optionsMonitor,
    [FromServices]MyDbContext dbContext) =>


{

    var myAuthors = new Author()
    {
        
        Name = "Alx",
        Createdat = DateTime.UtcNow,
        Id = Guid.NewGuid().ToString(),
        Books = new List<Book>()
        {
            new Book()
            {
                Title = "My first book",
                Createdat = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString()
            }
        }
    };
    
 
    
    dbContext.Authors.Add(myAuthors);

    //Author auth = dbContext.Authors.ToList().FirstOrDefault();
    //dbContext.Authors.Remove(auth);
    
    dbContext.SaveChanges();

    var objects= dbContext.Authors.ToList();
    return objects;
    
    
});

app.Run();
