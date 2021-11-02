using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated On")]
        public DateTime? Updated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Moderated On")]
        public DateTime? Moderated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Deleted On")]
        public DateTime? Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
        public virtual IdentityUser Author { get; set; }
        public virtual IdentityUser Moderator { get; set; }


    }
}
