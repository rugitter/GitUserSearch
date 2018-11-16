using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitUserSearch.Models
{
    public class User
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Company { get; set; }

    }
}
