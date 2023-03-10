using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class OddEvenNumberPlatView
	{
		private readonly IParkingAppService _parkingAppService;
		public OddEvenNumberPlatView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}
		public async Task DisplayView()
		{
			Console.Clear();
			Console.WriteLine("Choose the type of : ");
			Console.WriteLine("1. Odd");
			Console.WriteLine("2. Even");
			Console.Write("Choose your Option : ");
			string input = Console.ReadLine();
			if (input == "")
				return;
			if(input == "1")
			{
				var result = await _parkingAppService.GetOodVehicle();
				Console.WriteLine();
				if(result.Count != 0)
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
				
			}else if(input == "2")
			{
				var result = await _parkingAppService.GetEvenVehicle();
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
			else
			{
				Console.WriteLine("Invalid input, please try again.");
				return;
			}
		}
	}
}
