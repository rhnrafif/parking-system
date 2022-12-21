using ParkingSystem.Applications.Parks;
using ParkingSystem.Applications.Parks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class CreateParkingView
	{
		private readonly IParkingAppService _parkingAppService;
		public CreateParkingView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}

		public async Task DisplayView()
		{
			Console.Clear();
			Console.WriteLine("Input the vehicle data : (ex : B-3141-ZZZ Hitam Motor) : ");
			string input = Console.ReadLine().ToUpper();			

			if (input != "")
			{
				string[] data = input.Split(" ");

				if(data.Count() != 3)
				{
					Console.WriteLine("Input field is invalid format, please try again.");
					return;
				}

				string platNumber = data[0];
				string color = data[1];
				string type = data[2];

				if(platNumber == null && platNumber.Replace("-","").Count() != 8)
				{
					Console.WriteLine("Plat number is invalid format, please try again.");
					return;
				}

				//Dto
				CreateParkingDto model = new CreateParkingDto()
				{
					PlatNumber = platNumber,
					Type = type,
					Colour = color
				};

				var result = await _parkingAppService.CreatePark(model);
				if (result == 0)
				{
					Console.WriteLine("Sorry, parking lot is full");
				}
				else
				{
					Console.WriteLine($"Allocated Slot Number {result}");
				}
			}
			else
			{
				Console.WriteLine("Input field is invalid format, please try again.");
				return;
			}
				
		}
	}
}
