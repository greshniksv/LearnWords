using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWords.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public virtual List<UserWord> UserWords { get; set; }
    }
}