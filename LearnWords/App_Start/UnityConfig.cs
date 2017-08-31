using LearnWords.Authentication;
using Microsoft.Practices.Unity;

namespace LearnWords.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container
                //.RegisterType<IHashCalculator, Md5HashCalculator>()
                .RegisterType<IAuthentication, CustomAuthentication>();
        }
    }
}