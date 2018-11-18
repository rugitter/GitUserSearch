using System;
using System.ComponentModel.DataAnnotations;

namespace GitUserSearch.Models
{
    public class UserSearch
    {
        [Display(Name = "Search ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Access Date")]
        public DateTime AccessDate { get; set; }

        [Display(Name = "User Login")]
        public GitUser User { get; set; }
    }
}
