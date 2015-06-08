using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class Post
    {
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Blog post title")]
        [StringLength(100, MinimumLength = 5,
                      ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title { get; set; }

        public DateTime PostedDate { get; set; }

        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(5, ErrorMessage = "Blog post must be at least 5 characters long")]
        public string Body { get; set; }
    }
}
