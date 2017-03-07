using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }

        [Required]
        public string RegionName { get; set; }

        //links region to application user
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}