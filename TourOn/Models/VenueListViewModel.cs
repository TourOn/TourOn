using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
	public class VenueListViewModel
	{
		public IEnumerable<ApplicationUser> Venues { get; set; }
	}
}