using AutoMapper;
using ParkingSystem.Applications.Parks.Dto;
using ParkingSystem.Applications.Slots.Dto;
using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.ConfigProfile
{
	public class ConfigurationProfile : Profile
	{
		public ConfigurationProfile()
		{
			CreateMap<DisplayAllSlotDto, Slot>();
			CreateMap<Slot, DisplayAllSlotDto>();

			CreateMap<Parking, CreateParkingDto>();
			CreateMap<CreateParkingDto, Parking>();

			CreateMap<DisplayActiveParkingDto, Parking>();
			CreateMap<Parking, DisplayActiveParkingDto>();
		}
	}
}
