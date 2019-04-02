using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
	public class Recipie
	{
		int Id { get; set; }
		string RecipieName { get; set; }
		string CookTime { get; set; }
		string CookTemp { get; set; }
		string Directions { get; set; }
	}
}