using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnWords.Models.Db
{
    public class UserWord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserWordId { get; set; }
        public string RusWord { get; set; }
        public string Word { get; set; }
        public byte[] Image { get; set; }

        public Guid UserId { get; set; }
        public virtual User  User { get; set; }
    }
}