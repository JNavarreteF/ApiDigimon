using ApiDigimon.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDigimon.Data
{
	public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public virtual DbSet<Digimon> Digimons { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Name=ConnectionStrings:DatabaseContext");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Digimon>(entity =>
			{
				entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
