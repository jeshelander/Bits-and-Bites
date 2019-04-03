using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
	public class Recipie
	{
		public int Id { get; set; }
		public string RecipieName { get; set; }
		public string CookTime { get; set; }
		public string CookTemp { get; set; }
		public string Directions { get; set; }
	}
}