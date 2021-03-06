﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
	public class Recipie
	{
		public int Id { get; set; }
		public string RecipieName { get; set; }
		public string Ingredients { get; set; }
		public string CookTime { get; set; }
		public string Keywords { get; set; }
		public string Directions { get; set; }
		public int ImageID { get; set; }
		public DateTime DateSubmitted { get; set; }
		public int LikeCounter { get; set; }
		public string SubmittedByID { get; set; }
		public string SubmittedByName { get; set; }
	}
}