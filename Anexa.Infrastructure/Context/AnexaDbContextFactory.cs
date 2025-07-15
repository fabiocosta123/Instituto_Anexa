using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Anexa.Infrastructure.Context;

public class AnexaDbContextFactory : IDesignTimeDbContextFactory<AnexaDbContext>
{
    public AnexaDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<AnexaDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AnexaDbContext(optionsBuilder.Options);
    }
}