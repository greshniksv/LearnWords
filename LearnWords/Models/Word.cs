using System;

namespace LearnWords.Models
{
    public class Word
    {
        public Word()
        {
        }

        public Word(UserWord word)
        {
            Id = word.UserWordId;
            Value = word.Word;
        }

        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}