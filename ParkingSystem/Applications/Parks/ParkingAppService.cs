using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Applications.Parks.Dto;
using ParkingSystem.Applications.Slots;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Applications.Parks
{
	public class ParkingAppService : IParkingAppService
	{
		private readonly AppDbContext _context;
		private readonly ISlotAppService _slotAppService;
		private readonly IMapper _mapper;
		public ParkingAppService(AppDbContext context, ISlotAppService slotAppService, IMapper mapper)
		{
			_context = context;
			_slotAppService = slotAppService;
			_mapper = mapper;
		}
		public async Task<int> CreatePark(CreateParkingDto field)
		{
			try
			{
				var availableSlot = _slotAppService.DisplayAvailableSlot().Result.FirstOrDefault();
				if(availableSlot != null && field != null)
				{
					var parkingData = _mapper.Map<Parking>(field);
					parkingData.SlotId = availableSlot.Id;
					parkingData.IsFinished = false;

					await _context.Parkings.AddAsync(parkingData);
					await _context.SaveChangesAsync();

					//UPDATE SLOT AVAILABILITY
					await _slotAppService.UpdateAvailability(availableSlot.Id.ToString());

					return await Task.Run(() => (availableSlot.Slots));
				}
				return await Task.Run(() => (0));
			}
			catch
			{
				return await Task.Run(() => (0));
			}
		}

		public async Task<List<DisplayActiveParkingDto>> GetAllActiveParking()
		{
			try
			{
				List<DisplayActiveParkingDto> result = new List<DisplayActiveParkingDto>();
				var parkingData = await _context.Parkings.Where(w => w.IsFinished == false).ToListAsync();
				if(parkingData.Count != 0)
				{
					foreach( var item in parkingData)
					{
						var slotNumber = await _slotAppService.GetSlotById(item.SlotId);
						var data = new DisplayActiveParkingDto()
						{
							Id = item.Id,
							Colour = item.Colour,
							Type = item.Type,
							PlatNumber = item.PlatNumber,
							Slot = slotNumber.Slots
						};

						result.Add(data);
					}
					return await Task.Run(() => (result));
				}
				return await Task.Run(() => (result));
			}
			catch
			{
				return await Task.Run(() => (new List<DisplayActiveParkingDto>()));
			}
		}

		public async Task<List<string>> GetOodVehicle()
		{
			try
			{
				List<string> result = new List<string>();
				var vehicleData = await _context.Parkings.AsNoTracking().Where( w => w.IsFinished == false).ToListAsync();
				foreach(var item in vehicleData)
				{
					var plat = item.PlatNumber.Split("-");
					var number = plat[1].ToCharArray();

					if (Convert.ToInt32(number[3]) % 2 != 0)
						result.Add(item.PlatNumber);
				}
				return await Task.Run(() => (result));
			}
			catch
			{
				return await Task.Run(() => (new List<string>()));
			}
		}
		public async Task<List<string>> GetEvenVehicle()
		{
			try
			{
				List<string> result = new List<string>();
				var vehicleData = await _context.Parkings.AsNoTracking().Where(w => w.IsFinished == false).ToListAsync();
				foreach (var item in vehicleData)
				{
					var plat = item.PlatNumber.Split("-");
					var number = plat[1].ToCharArray();
					
					if (Convert.ToInt32(number[3]) % 2 == 0)
						result.Add(item.PlatNumber);
				}
				return await Task.Run(() => (result));
			}
			catch
			{
				return await Task.Run(() => (new List<string>()));
			}
		}

		public async Task<List<string>> GetSlotByVehicleColor(string color)
		{
			try
			{
				var vehicleList = await _context.Parkings.Where(w => w.Colour == color)
					.Where(w => w.IsFinished == false).ToListAsync();
				if(vehicleList.Count != 0)
				{
					List<string> result = new List<string>();
					foreach( var vehicle in vehicleList)
					{
						var slotNum = await _slotAppService.GetSlotById(vehicle.SlotId);
						result.Add(slotNum.Slots.ToString());
					}
					return await Task.Run(() => (result));
				}
				return await Task.Run(() => (new List<string>()));
			}
			catch
			{
				return await Task.Run(() => (new List<string>()));
			}
		}

		public async Task<int> GetSlotByVehicleNumber(string platNumber)
		{
			try
			{
				var vehicleData = await _context.Parkings.AsNoTracking().Where(w => w.IsFinished == false)
					.FirstOrDefaultAsync(w => w.PlatNumber == platNumber);
				if(vehicleData != null)
				{
					var slotNumber = await _slotAppService.GetSlotById(vehicleData.SlotId);
					return await Task.Run(() => (slotNumber.Slots));
				}
				return await Task.Run(() => (0));
			}
			catch
			{
				return await Task.Run(() => (0));
			}
		}

		public async Task<List<string>> GetVehicleByColor(string color)
		{
			try
			{
				var vehicleList = await _context.Parkings.Where(w => w.Colour.ToLower() == color.ToLower())
					.Where(w => w.IsFinished == false)
					.ToListAsync();
				if (vehicleList.Count != 0)
				{
					List<string> result = new List<string>();
					foreach (var vehicle in vehicleList)
					{
						result.Add(vehicle.PlatNumber);
					}

					if (result.Count != 0)
					{
						return await Task.Run(() => (result));
					}
				}
				return await Task.Run(() => (new List<string>()));
			}
			catch
			{
				return await Task.Run(() => (new List<string>()));
			}
		}

		public async Task<List<Parking>> GetVehicleByType(string type)
		{
			try
			{
				var vehicleData = await _context.Parkings.AsNoTracking()
					.Where(w => w.Type.ToLower() == type.ToLower())
					.Where( w => w.IsFinished == false)
					.ToListAsync();
				if(vehicleData.Count != 0)
				{
					return await Task.Run(() => (vehicleData));
				}
				return await Task.Run(() => (vehicleData));
			}
			catch
			{
				return await Task.Run(() => (new List<Parking>()));
			}
		}

		public async Task<bool> UpdateParkAvaibility(int slotNumber)
		{
			try
			{
				var slotId = await _slotAppService.GetSlotBySlotNumber(slotNumber);
				var parkData = await _context.Parkings.AsNoTracking().Where(w => w.IsFinished == false)
					.FirstOrDefaultAsync(w => w.SlotId == slotId.Id);

				if(parkData != null)
				{
					parkData.IsFinished = true;
					_context.Parkings.Update(parkData);
					_context.SaveChanges();

					//UPDATE SLOT AVAILABILITY
					await _slotAppService.UpdateAvailability(parkData.SlotId.ToString());

					return await Task.Run(() => (true));
				}
				return await Task.Run(() => (false));
			}
			catch
			{
				return await Task.Run(() => (false));
			}
		}
	}
}
