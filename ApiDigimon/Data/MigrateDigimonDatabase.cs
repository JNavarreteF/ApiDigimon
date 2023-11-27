using Microsoft.EntityFrameworkCore;

namespace ApiDigimon.Data
{
	public static class MigrateDigimonDatabase
	{
		public static void InitializeDatabase(IApplicationBuilder app)
		{
			Thread.Sleep(30000);
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
				if (context.Database.GetPendingMigrations().Any())
				{
					Console.WriteLine("Aplicando migraciones pendientes...");
					context.Database.Migrate();
					Console.WriteLine("Migraciones aplicadas.");
				}
				else
				{
					Console.WriteLine("No hay migraciones pendientes.");
				}
			}
		}
	}
}
