using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitUserSearch.Models
{
    public class GitUser
    {
        // Required attributes
        [Key, Display(Name = "Git ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        public string Login { get; set; }
        [Display(Name = "User Url")]
        public string Url { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Followers { get; set; }

        // Nonable attributes
        public string Company { get; set; }
        public string Email { get; set; }
    }
}
