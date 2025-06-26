using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PSKM.Data;

public static class MigrationService
{
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
                using IServiceScope scope = app.ApplicationServices.CreateScope();

                using AppDbContext appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                appDbContext.Database.Migrate();
        }
}