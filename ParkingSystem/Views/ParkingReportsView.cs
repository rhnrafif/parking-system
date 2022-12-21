using ParkingSystem.Views.Parkings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Views
{
	public class ParkingReportsView
	{
		private DisplayAllActiveParkingView _allActiveParkingView;
		private TotalParkingByTypeView _totalParkingByTypeView;
		private OddEvenNumberPlatView _oddEvenNumberPlatView;
		private VehicleNumberPlatByColorView _vehicleNumberPlatByColorView;
		private ParkingSlotByColorView _parkingSlotByColorView;
		private SearchSlotByPlatView _searchSlotByPlatView;
		public ParkingReportsView(DisplayAllActiveParkingView displayAllActiveParkingView, 
			TotalParkingByTypeView totalParkingByTypeView,
			OddEvenNumberPlatView oddEvenNumberPlatView,
			VehicleNumberPlatByColorView vehicleNumberPlatByColorView,
			ParkingSlotByColorView parkingSlotByColorView,
			SearchSlotByPlatView searchSlotByPlatView)
		{
			_allActiveParkingView = displayAllActiveParkingView;
			_totalParkingByTypeView = totalParkingByTypeView;
			_oddEvenNumberPlatView = oddEvenNumberPlatView;
			_vehicleNumberPlatByColorView = vehicleNumberPlatByColorView;
			_parkingSlotByColorView = parkingSlotByColorView;
			_searchSlotByPlatView = searchSlotByPlatView;
		}
		public async Task DisplayView()
		{
			bool showMenu = true;
			while (showMenu)
			{
				Console.Clear();
				Console.WriteLine("Reports Parking Menu");
				Console.WriteLine("========================");
				Console.WriteLine("1.All Active Parking Records");
				Console.WriteLine("2.Total Parking Record by Type");
				Console.WriteLine("3.Display Vehicle Odd Even Number Plat");
				Console.WriteLine("4.Display Vehicle Number Plat by Color");
				Console.WriteLine("5.Display Parking Slot by Color");
				Console.WriteLine("6.Search Slot Number By Plat Number");
				Console.WriteLine("7.Exit ");
				Console.WriteLine("Input your choice : ");

				switch (Console.ReadLine())
				{
					case "1":
						await _allActiveParkingView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "2":
						await _totalParkingByTypeView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "3":
						await _oddEvenNumberPlatView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "4":
						await _vehicleNumberPlatByColorView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "5":
						await _parkingSlotByColorView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "6":
						await _searchSlotByPlatView.DisplayView();
						Console.ReadKey();
						showMenu = true;
						break;
					case "7":
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
