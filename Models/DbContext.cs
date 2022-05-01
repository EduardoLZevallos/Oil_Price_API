using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using OilPrice.Models;

namespace OilPrice.Models
{
	public class OilPriceAPIDBContext : DbContext
    {
		protected readonly IConfiguration Configuration;

		public OilPriceAPIDBContext(DbContextOptions<OilPriceAPIDBContext> options, IConfiguration configuration) : base(options)
        {
			Configuration = configuration;
        }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			var connectionString = Configuration.GetConnectionString("OilPriceDataService");
			options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

		public DbSet<OilPrice.Models.ConventionalGasoline> ConventionalGasoline { get; set; } = null!;
		public DbSet<OilPrice.Models.CrudeOil> CrudeOil { get; set; } = null!;
	}
}

