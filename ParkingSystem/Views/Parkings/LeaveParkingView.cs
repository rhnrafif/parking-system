using ParkingSystem.Applications.Parks.Dto;
using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class LeaveParkingView
	{
		private readonly IParkingAppService _parkingAppService;
		public LeaveParkingView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}

		public async Task DisplayView()
		{
			Console.Clear();
			Console.WriteLine("Input the park lot number : (ex : 1) : ");
			int input = int.Parse(Console.ReadLine());

			if (input != 0)
			{
				var result = await _parkingAppService.UpdateParkAvaibility(input);
				if (result)
				{
					Console.WriteLine($"Slot number {input} is free");
				}
				else
				{
					Console.WriteLine($"Slot number not found");
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
