using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class AccountType
    {
        //links account type to application user
        public virtual ApplicationUser ApplicationUser { get; set; }

        //links account type to bands and venues
        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<Band> Bands { get; set; }
    }
}