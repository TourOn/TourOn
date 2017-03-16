using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class CommentViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Comment Comment { get; set; }
    }
}