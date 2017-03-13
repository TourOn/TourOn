using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
	public class ProfileViewModel
	{
		public string Name { get; set; }
		
		[Display(Name = "City")]
		public string City { get; set; }
		
		[Display(Name = "State")]
		public string State { get; set; }
		
		[Display(Name = "Public email")]
		public string PublicEmail { get; set; }

		public string Description { get; set; }
		
		[Phone]
		public string Phone { get; set; }

		public string Region { get; set; }

		[Display(Name = "Genre")]
		public string Genre { get; set; }

		//Venue-specific fields
		[Display(Name = "Street")]
		public string Street { get; set; }

		[Display(Name = "Zip Code")]
		public int Zip { get; set; }

		[Display(Name = "Capacity")]
		public int Capacity { get; set; }

		public string Equipment { get; set; }

		public string Parking { get; set; }

		//Band-specific fields
		[Display(Name = "Members in band")]
		public int Size { get; set; }

		public string Showcase { get; set; }

	}
}