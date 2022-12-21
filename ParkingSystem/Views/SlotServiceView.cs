using ParkingSystem.Applications.Slots;
using ParkingSystem.Views.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views
{
	public class SlotServiceView
	{
		private CreateSlotView _view;
		private ShowAvailabelSlotView _showAvailabelSlotView;
		public SlotServiceView(CreateSlotView view, ShowAvailabelSlotView showAvailabelSlotView)
		{
			_view = view;
			_showAvailabelSlotView = showAvailabelSlotView;
		}

		public async Task DisplayView()
		{
			bool showMenu = true;
			while (showMenu)
			{
				Console.Clear();
				Console.WriteLine("Parking Slot Menu");
				Console.WriteLine("=================");
				Console.WriteLine("1.Create Slot");
				Console.WriteLine("2.Show Available Slot");
				Console.WriteLine("3.Show Filled Slot");
				Console.WriteLine("4.Exit ");
				Console.WriteLine("Input your choice : ");

				switch (Console.ReadLine())
				{
					case "1":
						await _view.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "2":
						await _showAvailabelSlotView.DisplayAvailableView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "3":
						await _showAvailabelSlotView.DisplayUnavailableView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "4":
						showMenu = false;
						break;
					default:
						showMenu = true;
						break;
				}
			}			
		}
	}
}
