using System.ComponentModel.DataAnnotations;

namespace api;

public class AppOptions
{
    [MinLength(length: 1)]
    public string DbConnectionString { get; set; }
    [MinLength(length: 1)]
    public string JwtSecret { get; set; }
}