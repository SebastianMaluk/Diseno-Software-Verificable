using System.ComponentModel.DataAnnotations;

namespace RealState.Models
{
	public class Adquiriente
	{
		public int id { get; set; }
		public string? Rut { get; set; }
		public int Percentage_right { get; set; }
		public int Check_percentage_not_credited { get; set; }
		public Inscription? Inscription { get; set; }
	}
}
