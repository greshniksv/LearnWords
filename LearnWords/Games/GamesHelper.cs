using System;
using System.Collections.Generic;
using System.Linq;
using LearnWords.Models.Api;

namespace LearnWords.Games
{
    public static class GamesHelper
    {
        private static Dictionary<Guid, IGame> games;
        private static List<GameInfo> gameInfos;

        public static List<GameInfo> ListInfos {
            get
            {
                if (gameInfos == null)
                {
                    LoadGames();
                }
                return gameInfos;
            }
        }

        public static IGame Get(Guid id)
        {
            return games.FirstOrDefault(x => x.Key == id).Value;
        }

        private static void LoadGames()
        {
            var list = new Dictionary<Guid, IGame>();
            var type = typeof(IGame);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var itemType in types.Where(x=>!x.IsInterface))
            {
                list.Add(Guid.NewGuid(), Activator.CreateInstance(itemType) as IGame);
            }
            gameInfos = list.Select(x => new GameInfo {Id = x.Key, Details = x.Value.Details, Name = x.Value.Name}).ToList();
            games = list;
        }
    }
}