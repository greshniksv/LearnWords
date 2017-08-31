using System;
using System.Web;
using LearnWords.Authentication;
using Microsoft.Practices.Unity;

namespace LearnWords.Modules
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Authenticate;
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }

        private void Authenticate(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            var auth = MvcApplication.Unity.Resolve<IAuthentication>();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
        }

        public void Dispose()
        {
        }
    }
}