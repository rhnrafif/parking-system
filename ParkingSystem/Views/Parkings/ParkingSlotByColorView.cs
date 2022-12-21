using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class ParkingSlotByColorView
	{
		private readonly IParkingAppService _parkingAppService;
		public ParkingSlotByColorView(IParkingAppService parkingAppService)
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
				var result = _parkingAppService.GetSlotByVehicleColor(input).Result;

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
