using System.Collections.Generic;

namespace LearnWords.Games
{
    public interface IGame
    {
        string Name { get; set; }
        string Details { get; set; }
        string JsEngine { get; set; }
        List<string> CommonLibs { get; set; }
    }
}