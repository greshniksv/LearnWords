using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnWords.Models.Db
{
    public class Dictionary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DictionaryId { get; set; }
        public string Name { get; set; }

        public virtual List<UserWord> UserWords { get; set; }
    }
}