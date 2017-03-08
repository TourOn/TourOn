using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Venue : ApplicationUser
    {
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public int Capacity { get; set; }


        public string Parking { get; set; }
        public string Equipment { get; set; }
        
    }
}