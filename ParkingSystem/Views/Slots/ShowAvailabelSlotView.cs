using ParkingSystem.Applications.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views.Slots
{
	public class ShowAvailabelSlotView
	{
		private readonly ISlotAppService _slotAppService;
		public ShowAvailabelSlotView(ISlotAppService slotAppService)
		{
			_slotAppService = slotAppService;
		}
		public async Task DisplayAvailableView()
		{
			Console.Clear();
			Console.WriteLine("Available Parking Slot");
			Console.WriteLine("======================");

			var result = await _slotAppService.DisplayAvailableSlot();
			if(result.Count != 0)
			{
				foreach(var slot in result)
				{
					Console.WriteLine($" Lot {slot.Slots}");
				}
				Console.WriteLine($"Total : {result.Count}");
			}
			else
			{
				Console.WriteLine("Lot are full");
			}
		}
		public async Task DisplayUnavailableView()
		{
			Console.Clear();
			Console.WriteLine("Parking lot Filled");
			Console.WriteLine("======================");

			var result = await _slotAppService.DisplayUnavailableSlot();
			if (result.Count != 0)
			{
				foreach (var slot in result)
				{
					Console.WriteLine($" Lot {slot.Slots}");
				}
			}
			else
			{
				Console.WriteLine("All slot is available");
			}
		}
	}
}
