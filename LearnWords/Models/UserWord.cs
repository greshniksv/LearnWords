using System;

namespace LearnWords.Models
{
    public class UserWord
    {
        public Guid UserWordId { get; set; }
        public string Word { get; set; }

        public Guid UserId { get; set; }
        public virtual User  User { get; set; }
    }
}