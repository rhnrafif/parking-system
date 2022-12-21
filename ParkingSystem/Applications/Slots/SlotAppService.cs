using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Applications.Slots;
using ParkingSystem.Applications.Slots.Dto;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Applications.Slots
{
	public class SlotAppService : ISlotAppService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		public SlotAppService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<bool> CreateSlot(int input)
		{
			try
			{
				if(input > 0)
				{
					for(int i =1; i <= input; i++)
					{
						Slot slotData = new Slot();
						slotData.Id = Guid.NewGuid();
						slotData.Slots = i;
						slotData.IsAvailable = true;

						await _context.Slots.AddAsync(slotData);
						await _context.SaveChangesAsync();
					}
					return await Task.Run(() => (true));
				}
				return await Task.Run(() => (false));
			}
			catch
			{
				return await Task.Run(() => (false));
			}
		}

		public async Task<List<DisplayAllSlotDto>> DisplayAllSlot()
		{
			try
			{
				List<DisplayAllSlotDto> result = new List<DisplayAllSlotDto>();
				var slotData = await _context.Slots.AsNoTracking().OrderBy(w => w.Slots).ToListAsync();

				if (slotData.Count != 0)
				{					
					foreach( var item in slotData)
					{						
						result.Add(_mapper.Map<DisplayAllSlotDto>(item));
					}
					return await Task.Run(() => (result));
				}
				return await Task.Run(() => (result = null));
			}
			catch
			{
				return await Task.Run(() => (new List<DisplayAllSlotDto>()));
			}
		}

		public async Task<List<Slot>> DisplayAvailableSlot()
		{
			try
			{
				var slotData = await _context.Slots.AsNoTracking().Where(w => w.IsAvailable == true).OrderBy(w => w.Slots).ToListAsync();
				if(slotData.Count != 0)
				{
					return await Task.Run(()=>(slotData));
				}
				return await Task.Run(()=>(slotData = null));
			}
			catch
			{
				return await Task.Run(() => (new List<Slot>()));
			}
		}

		public async Task<List<Slot>> DisplayUnavailableSlot()
		{
			try
			{
				var slotData = await _context.Slots.AsNoTracking().Where(w => w.IsAvailable == false).OrderBy(w => w.Slots).ToListAsync();
				if (slotData.Count != 0)
				{
					return await Task.Run(() => (slotData));
				}
				return await Task.Run(() => (slotData = null));
			}
			catch
			{
				return await Task.Run(() => (new List<Slot>()));
			}
		}

		public async Task<Slot> GetSlotById(Guid id)
		{
			try
			{
				if(id != null)
				{
					var slotData = await _context.Slots.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
					return await Task.Run(() => (slotData));
				}
				return await Task.Run(()=>(new Slot()));
			}
			catch
			{
				return await Task.Run(() => (new Slot()));
			}
		}

		public async Task<Slot> GetSlotBySlotNumber(int number)
		{
			try
			{
				if (number != 0)
				{
					var slotData = await _context.Slots.AsNoTracking().FirstOrDefaultAsync(w => w.Slots == number);
					return await Task.Run(() => (slotData));
				}
				return await Task.Run(() => (new Slot()));
			}
			catch
			{
				return await Task.Run(() => (new Slot()));
			}
		}

		public async Task<bool> UpdateAvailability(string id)
		{
			try
			{
				if(id != null)
				{
					Guid slotId = Guid.Parse(id);
					var slotData = await GetSlotById(slotId);

					if(slotData != null)
					{
						if(slotData.IsAvailable == true)
						{
							slotData.IsAvailable = false;
						}
						else
						{
							slotData.IsAvailable = true;
						}						
						_context.Slots.Update(slotData);
						_context.SaveChanges();
						return await Task.Run(() => (true));
					}

					return await Task.Run(() => (false));
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
