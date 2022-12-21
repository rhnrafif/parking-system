using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
	[Table("slot", Schema = "dbo")]
	public class Slot
	{
		[Key]
		public Guid Id { get; set; }
		public int Slots { get;set; }
		public bool IsAvailable { get;set; }
	}
}
