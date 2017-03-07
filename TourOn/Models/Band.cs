using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Band
    {
        [Key]
        public int BandID { get; set; }

        //links account type to band
        public virtual AccountType AccountType { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Size { get; set; }
        //not required
        public string Showcase { get; set; }
    }
}