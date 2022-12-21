using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingSystem.Applications.Parks;
using ParkingSystem.Applications.Slots;
using ParkingSystem.ConfigProfile;
using ParkingSystem.Models;
using ParkingSystem.Views;
using ParkingSystem.Views.Parkings;
using ParkingSystem.Views.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
	public class Startup
	{
		IConfigurationRoot Configuration { get; }
		public IServiceProvider Provider { get; }
		public Startup()
		{
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
			Configuration = config.Build();
			Provider = ConfigureService();
		}

		private IServiceProvider ConfigureService()
		{
			var services = new ServiceCollection();

			//context
			services.AddDbContext<AppDbContext>(cfg =>
			{
				cfg.UseSqlServer(Configuration.GetConnectionString("DbConnection"), 
					builder => builder.MigrationsAssembly("migration.presentence"));
			}, ServiceLifetime.Transient);

			//automapper
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ConfigurationProfile());
			});
			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			//service
			services.AddTransient<ISlotAppService, SlotAppService>();
			services.AddTransient<IParkingAppService, ParkingAppService>();

			//view
			//slots
			services.AddTransient<SlotServiceView>();
			services.AddTransient<CreateSlotView>();
			services.AddTransient<ShowAvailabelSlotView>();

			//parking
			services.AddTransient<ParkingTransactionView>();
			services.AddTransient<ParkingReportsView>();

			services.AddTransient<CreateParkingView>();
			services.AddTransient<LeaveParkingView>();
			services.AddTransient<DisplayAllActiveParkingView>();
			services.AddTransient<TotalParkingByTypeView>();
			services.AddTransient<OddEvenNumberPlatView>();
			services.AddTransient<VehicleNumberPlatByColorView>();
			services.AddTransient<ParkingSlotByColorView>();
			services.AddTransient<SearchSlotByPlatView>();			

			return services.BuildServiceProvider();
		}
	}
}
