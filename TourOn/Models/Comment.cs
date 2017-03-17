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
        public string AuthorID { get; set; }
        public string SubjectID { get; set; }

        [Required]
        public bool ThumbsUp { get; set; }
        [Required]
        [StringLength(140)]
        public string CommentHeader { get; set; }
        //not required
        public string CommentBody { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt | ddd, MMM d, yyyy}")]
        public DateTime PublishDate = DateTime.Now;
    }
}