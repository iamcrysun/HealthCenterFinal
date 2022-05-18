using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    // Фабрика для создания производных DbContext экземпляров. Необходима для выполнения миграций,
    // связанных с добавлением ролей
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HealthyContext>
    {
        public HealthyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.
                GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<HealthyContext>();
            var connectionString =
            configuration.GetConnectionString("DefaultConnection"); 
            builder.UseSqlServer(connectionString);
            return new HealthyContext(builder.Options);
        }
    }

}
