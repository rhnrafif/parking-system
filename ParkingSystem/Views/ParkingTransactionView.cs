using ParkingSystem.Views.Parkings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views
{
	public class ParkingTransactionView
	{
		private CreateParkingView _parkingView;
		private LeaveParkingView _leaveParking;
		public ParkingTransactionView(CreateParkingView createParkingView, LeaveParkingView leaveParking)
		{
			_parkingView = createParkingView;
			_leaveParking = leaveParking;
		}
		public void DisplayView()
		{	
			bool showMenu = true;
			while (showMenu)
			{
				Console.Clear();
				Console.WriteLine("Parking Menu");
				Console.WriteLine("1.Create Parking");
				Console.WriteLine("2.Leave Parking");
				Console.WriteLine("3.Exit");
				Console.WriteLine("Input your choice : ");

				switch (Console.ReadLine())
				{
					case "1":
						_parkingView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "2":
						_leaveParking.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "3":
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
