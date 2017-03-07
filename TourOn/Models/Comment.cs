using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourOn.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        //links comment to author and subject
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Subject { get; set; }

        [Required]
        public bool ThumbsUp { get; set; }
        [Required]
        [StringLength(140)]
        public string CommentHeader { get; set; }
        //not required
        public string CommentBody { get; set; }
    }
}