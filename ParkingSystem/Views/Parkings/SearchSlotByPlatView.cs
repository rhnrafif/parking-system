using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class SearchSlotByPlatView
	{
		private IParkingAppService _parkingAppService;
		public SearchSlotByPlatView(IParkingAppService parkingAppService)
		{
			_parkingAppService = parkingAppService;
		}
		public async Task DisplayView()
		{
			Console.Clear();
			Console.Write("Input the plat number : (ex : B-1987-YHU) : ");
			string input = Console.ReadLine().ToLower();

			string data = input.Replace("-","");

			if (data.Count() > 8 || data.Count() < 7 )
			{
				Console.WriteLine("Input field is invalid format, please try again.");
				return;
			}

			var result = await _parkingAppService.GetSlotByVehicleNumber(input);
			if(result != 0)
				Console.WriteLine($"Parking lot : {result}");
			else
				Console.WriteLine("Not Found");
		}
	}
}
