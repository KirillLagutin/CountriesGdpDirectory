using Microsoft.EntityFrameworkCore;
using CountriesGdpDirectory.Models.Entities;

namespace CountriesGdpDirectory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<GDP> GDPs => Set<GDP>();
        public DbSet<Country> Countries => Set<Country>();

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
