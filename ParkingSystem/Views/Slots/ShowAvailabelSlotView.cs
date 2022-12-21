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
		public void DisplayAvailableView()
		{
			Console.Clear();
			Console.WriteLine("Available Parking Slot");
			Console.WriteLine("======================");

			var result = _slotAppService.DisplayAvailableSlot().Result;
			if(result.Count != 0)
			{
				foreach(var slot in result)
				{
					Console.WriteLine($" Lot {slot.Slots}");
				}
			}
			else
			{
				Console.WriteLine("Lot are full");
			}
		}
		public void DisplayUnavailableView()
		{
			Console.Clear();
			Console.WriteLine("Parking lot Filled");
			Console.WriteLine("======================");

			var result = _slotAppService.DisplayUnavailableSlot().Result;
			if (result.Count != 0)
			{
				foreach (var slot in result)
				{
					Console.WriteLine($" Lot {slot.Slots}");
				}
			}
			else
			{
				Console.WriteLine("Lot are full");
			}
		}
	}
}
