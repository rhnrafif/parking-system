using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
	[Table("parking", Schema = "dbo")]
	public class Parking
	{
		[Key]
		public Guid Id { get; set; }
		public Guid SlotId { get; set; }
		public string PlatNumber { get; set; }
		public string Type { get; set; }
		public string Colour { get; set; }
		public bool IsFinished { get; set; }
		public virtual Slot Slot { get; set; }
	}
}
