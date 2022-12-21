using ParkingSystem.Applications.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Slots
{
	public class CreateSlotView
	{
		private readonly ISlotAppService _slotAppService;
		public CreateSlotView(ISlotAppService slotAppService)
		{
			_slotAppService = slotAppService;
		}
		public async Task DisplayView()
		{
			Console.Clear();

			Console.WriteLine("How many slots do you want to create ? (press 0 to exit)");
			int input = int.Parse(Console.ReadLine());

			if (input == 0)
				return;

			var result = await _slotAppService.CreateSlot(input);

			if (!result)
			{
				Console.WriteLine("Failed to create slot, Please Try Again");
			}
			else
			{
				Console.Clear();
				Console.WriteLine($"Created parking lot with {input} slots !");
			}
		}
	}
}
