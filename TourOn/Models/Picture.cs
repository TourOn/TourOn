using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }

        //links account type to application user
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(140)]
        public string FileName { get; set; }
    }
}