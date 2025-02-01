using BaltaBlogEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaltaBlogEF.Data;

public class BaltaBlogEFDataContext : DbContext
{
    // É recomendado que o nome dessa propriedade seja
    // o nome da model no plural 
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    // public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }

    private readonly string CONNECTION_STRING;

    public BaltaBlogEFDataContext()
    {
        // Configuração do appsettings.json e variáveis de ambiente
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Define a raiz do projeto
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        // Recuperando a string de conexão
        CONNECTION_STRING = config["ConnectionStrings:CONNECTION_STRING"];
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(CONNECTION_STRING);


}

