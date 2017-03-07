using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }

        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Capacity { get; set; }

        //links account type to application user
        public virtual AccountType AccountType { get; set; }

        //not required
        public string Parking { get; set; }
        public string Equipment { get; set; }
        
    }
}