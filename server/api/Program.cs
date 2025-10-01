using System.Text.Json;
using api;
using api.Services;
using efscaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();


var appOptions = builder.Services.AddAppOptions(builder.Configuration);

builder.Services.AddScoped<IAuthorService, AuthorService>();


builder.Services.AddControllers();  
builder.Services.AddOpenApiDocument();
builder.Services.AddCors();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    
    conf.UseNpgsql(appOptions.DbConnectionString);
});



var app = builder.Build();

app.UseExceptionHandler();

app.UseCors(config => config.
    AllowAnyHeader().
    AllowAnyMethod().
    AllowAnyOrigin().
    SetIsOriginAllowed(x => true));

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();




app.Run();
