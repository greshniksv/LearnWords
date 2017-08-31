
namespace LearnWords.Models
{
    public class JsonState
    {
        public string Property { get; set; }
        public string Value { get; set; }

        public JsonState(string property, string value)
        {
            Property = property;
            Value = value;
        }

        public JsonState()
        {
        }
    }
}