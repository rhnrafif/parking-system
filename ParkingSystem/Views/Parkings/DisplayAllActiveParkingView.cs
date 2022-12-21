using ParkingSystem.Applications.Parks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Parkings
{
	public class DisplayAllActiveParkingView
	{
		private readonly IParkingAppService _parkingAppService;
		public DisplayAllActiveParkingView(IParkingAppService parkingAppService)
		{
			_parkingAppService= parkingAppService;
		}
		public async Task DisplayView()
		{
			Console.WriteLine();
			Console.WriteLine("==== All Active Parking ====");
			Console.WriteLine();
			Console.WriteLine("Slot - Plat Number - Type - Color");
			var res = await _parkingAppService.GetAllActiveParking();
			var result = res.OrderBy(w => w.Slot);

			foreach (var item in result)
			{
				Console.WriteLine($"{item.Slot} - {item.PlatNumber} - {item.Type} - {item.Colour}");
			}
			Console.WriteLine();
			Console.WriteLine($"Total : {result.Count()}");
		}
	}
}
