using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class TotalParkingByTypeView
	{
		private readonly IParkingAppService _parkingAppService;
		public TotalParkingByTypeView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}
		public async Task DisplayView()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("==== Total Active Parking ====");
			Console.Write("Please input type of vehicle : ");
			string input = Console.ReadLine().ToLower();

			if(input != "")
			{
				if(input == "mobil")
				{
					var result = await _parkingAppService.GetVehicleByType(input);
					if(result.Count != 0)
						Console.WriteLine($"Total for mobil is {result.Count}");
					else
						Console.WriteLine($"Not found");
				}
				else if(input == "motor")
				{
					var result = await _parkingAppService.GetVehicleByType(input);
					if (result.Count != 0)
						Console.WriteLine($"Total for motor is {result.Count}");
					else 
						Console.WriteLine($"Not found");
				}
				else
				{
					Console.WriteLine("Please input type of vehicle corrrectly");
					return;
				}
			}
		}
	}
}
