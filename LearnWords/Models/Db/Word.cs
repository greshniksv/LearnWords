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
            RusWord = word.RusWord;
            OtherWord = word.Word;
            Image = word.Image;
        }

        public Guid Id { get; set; }
        public string RusWord { get; set; }
        public string OtherWord { get; set; }
        public byte[] Image { get; set; }
    }
}