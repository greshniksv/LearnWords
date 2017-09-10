using System.Collections.Generic;

namespace LearnWords.Games
{
    public interface IGame
    {
        string Name { get; }
        string Details { get; }
        string JsEngine { get; }
        List<string> CommonLibs { get; }
    }
}