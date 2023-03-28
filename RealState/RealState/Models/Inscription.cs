using System.ComponentModel.DataAnnotations;

namespace RealState.Models
{
	public class Inscription
	{
		public int id { get; set; }
		public int attention_number { get; set; }
		public Cne? Cne { get; set; }
		public Localization? Localization { get; set; }
		public int fojas { get; set; }
		public DateTime date { get; set; }
		public int number { get; set; }
	}
}
