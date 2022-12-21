using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class VehicleNumberPlatByColorView
	{
		private IParkingAppService _parkingAppService;
		public VehicleNumberPlatByColorView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}
		public async Task DisplayView()
		{
			Console.Clear();
			Console.Write("Input vehicle color : ");
			string input = Console.ReadLine().ToLower();

			if (input != "")
			{
				var result = await _parkingAppService.GetVehicleByColor(input);
				
				Console.WriteLine();
				if (result.Count != 0)
				{
					foreach (var vehicle in result)
					{
						Console.Write($"{vehicle}, ");
					}
					Console.WriteLine();
					Console.WriteLine($"Total : {result.Count}");
				}
				else
				{
					Console.WriteLine("Not Found");
					return;
				}
				
			}			
		}
	}
}
