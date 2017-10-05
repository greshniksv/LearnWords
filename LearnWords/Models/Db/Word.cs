using System;

namespace LearnWords.Models.Db
{
    public class Word
    {
        public Word()
        {
        }

        public Word(UserWord word)
        {
            Id = word.UserWordId;
            Description = word.Description;
            Value = word.Word;
            HasImage = word.Image?.Length > 0;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool HasImage { get; set; }
    }
}