using ParkingSystem.Applications.Slots.Dto;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Applications.Slots
{
	public interface ISlotAppService
	{
		Task<bool> CreateSlot(int input);
		Task<bool> UpdateAvailability(string id);
		Task<Slot> GetSlotById(Guid id);
		Task<Slot> GetSlotBySlotNumber(int number);
		Task<List<Slot>> DisplayAvailableSlot();
		Task<List<Slot>> DisplayUnavailableSlot();
		Task<List<DisplayAllSlotDto>> DisplayAllSlot();
	}
}
