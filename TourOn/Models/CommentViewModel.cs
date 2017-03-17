using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class CommentViewModel
    {
        //the current profile being viewed
        public ApplicationUser ApplicationUser { get; set; }
        //the new comment form
        public Comment Comment { get; set; }
        //comments for the profile
        public IEnumerable<Comment> Comments { get; set; }
    }
}