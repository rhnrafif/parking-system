using ParkingSystem.Applications.Parks.Dto;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Applications.Parks
{
	public interface IParkingAppService
	{
		Task<int> CreatePark(CreateParkingDto field);
		Task<bool> UpdateParkAvaibility(int slotNumber);
		Task<List<DisplayActiveParkingDto>> GetAllActiveParking();
		Task<List<string>> GetOodVehicle();
		Task<List<string>> GetEvenVehicle();
		Task<List<string>> GetVehicleByColor(string color);
		Task<List<Parking>> GetVehicleByType(string type);
		Task<List<string>> GetSlotByVehicleColor(string color);
		Task<int> GetSlotByVehicleNumber(string platNumber);
	}
}
