namespace AdminUserActionsApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class User
    {

        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Fullname")]
        [Required(ErrorMessage = "The FullName is required!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The FullName length should be between {2} and {1}")]
        public string FullName { get; set; }

        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DateRegister { get; set; }

        
    }
}