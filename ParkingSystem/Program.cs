using Microsoft.Extensions.DependencyInjection;
using ParkingSystem;
using ParkingSystem.Views;

class Program
{
	static async Task Main(string[] args)
	{
		Startup startup = new Startup();
		var slotMenu = startup.Provider.GetService<SlotServiceView>();
		var parkMenu = startup.Provider.GetService<ParkingTransactionView>();
		var reportPark = startup.Provider.GetService<ParkingReportsView>();

		bool showMenu = true;
		while (showMenu)
		{
			Console.Clear();
			Console.WriteLine("        WELCOME TO       ");
			Console.WriteLine("=========================");
			Console.WriteLine("==== Parking Systems ====");
			Console.WriteLine("=========================");
			Console.WriteLine("1.Parking Slot Menu");
			Console.WriteLine("2.Parking Transaction");
			Console.WriteLine("3.Parking Reports");
			Console.WriteLine("4. Exit");
			Console.WriteLine("Please input menu that you want to : ");

			switch (Console.ReadLine())
			{
				case "1":
					await slotMenu.DisplayView();
					showMenu = true;
					break;
				case "2":
					await parkMenu.DisplayView();
					showMenu = true;
					break;
				case "3":
					await reportPark.DisplayView();
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