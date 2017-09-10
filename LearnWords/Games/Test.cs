using System.Collections.Generic;

namespace LearnWords.Games
{
    public class TestGame : IGame
    {
        public string Name => "Test game";
        public string Details => "It's first game <br /> which i created and <br /> which i will be test";
        public string JsEngine => "test.js";
        public List<string> CommonLibs => new List<string>() {" test_common.js"};
    }
}