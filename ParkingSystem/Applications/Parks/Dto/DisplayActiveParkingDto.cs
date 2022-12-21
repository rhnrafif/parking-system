using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Applications.Parks.Dto
{
	public class DisplayActiveParkingDto
	{
		public Guid Id { get; set; }
		public int Slot { get; set; }
		public string PlatNumber { get; set; }
		public string Type { get; set; }
		public string Colour { get; set; }
	}
}
