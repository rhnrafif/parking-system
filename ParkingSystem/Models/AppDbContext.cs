using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Parking> Parkings { get; set; }
		public DbSet<Slot> Slots { get; set; }
		public AppDbContext()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var conStr = "Server=RHNRAFIF\\SQLEXPRESS;Database=ParkingDB;Trusted_Connection=True;TrustServerCertificate=True;";
			optionsBuilder.UseSqlServer(conStr);
		}
	}
}
