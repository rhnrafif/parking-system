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
		public void DisplayView()
		{
			Console.Clear();
			Console.Write("Input vehicle color : ");
			string input = Console.ReadLine().ToLower();

			if (input != "")
			{
				var result = _parkingAppService.GetVehicleByColor(input).Result;
				
				Console.WriteLine();
				if (result.Count != 0)
				{
					foreach (var vehicle in result)
					{
						Console.Write($"{vehicle}, ");
					}
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
